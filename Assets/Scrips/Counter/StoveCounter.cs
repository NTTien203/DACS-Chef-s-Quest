using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounter : BaseCounter,IHasProgress
{
    [SerializeField] FryingSO[] fryingSO;
    [SerializeField] BurnSO[] burnSO;
    float fryingTimes;
    float burningTimes;
    [SerializeField]State state;
    public event EventHandler<IHasProgress.onProgressEventArgs> OnProgress;
     public class onProgressEventArgs: EventArgs{
        public float progress;
    }
    public enum State{
        idle,
        frying,
        fried,
        burned,
    }

    private void Start() {
        state=State.idle;
    }
    private void Update() {
        switch(state){
        case State.idle:
            break;
        case State.frying:
        fryingTimes+=Time.deltaTime;
        if(hasKitchenObj())
        {
            
                KitchenObjectSO outputKitchenObj=getOutputKitchenObj(GetKitchenObj().GetKitchenObjectSO());
            OnProgress?.Invoke(this,new IHasProgress.onProgressEventArgs{
                progress=fryingTimes/getFryingKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).FryingTimes
            });
            if(fryingTimes>=getFryingKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).FryingTimes){
                GetKitchenObj().DestroyKitchenObj();
                GameObject kitchenObj=Instantiate(outputKitchenObj.prefab);
                KitchenObject kitchenObject = kitchenObj.GetComponent<KitchenObject>();
                kitchenObject.setkitchenObjParent(this);

            fryingTimes=0;
            state=State.fried;    
            }
            
            
        }
            break;
        case State.fried:
        burningTimes+=Time.deltaTime;
        if(hasKitchenObj()){
             KitchenObjectSO outputKitchenObj=getBurningKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).output;
             OnProgress?.Invoke(this,new IHasProgress.onProgressEventArgs{
                progress=burningTimes/getBurningKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).BurningTimes
            });
             if(burningTimes>=getBurningKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).BurningTimes){
                GetKitchenObj().DestroyKitchenObj();
                GameObject kitchenObj=Instantiate(outputKitchenObj.prefab);
                kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(this);
            burningTimes=0;
             OnProgress?.Invoke(this,new IHasProgress.onProgressEventArgs{
                progress=0f
            });
            state=State.burned;
             }
        }
            break;
        case State.burned:
            break;
        }
    }

    
    public override void Interact(Player player){
      if(!hasKitchenObj()){
         if(player.hasKitchenObj()){
            if(hasObjFrying(player.GetKitchenObj().GetKitchenObjectSO())){
            player.GetKitchenObj().setkitchenObjParent(this);
            state=State.frying;
            fryingTimes=0;
            burningTimes=0;
           
         }
         }
      }else{
         if(!player.hasKitchenObj()){
            GetKitchenObj().setkitchenObjParent(player);
         }
         if(player.hasKitchenObj()){
             if(player.GetKitchenObj().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
                if(plateKitchenObj.TryAddIngredient(GetKitchenObj().GetKitchenObjectSO())){
                GetKitchenObj().DestroyKitchenObj();
            }
          
           }
         }
      }
        OnProgress?.Invoke(this,new IHasProgress.onProgressEventArgs{
                progress=0f
            });
   }

    public KitchenObjectSO getOutputKitchenObj(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in fryingSO){
            if(a.input==InputCuttingKitchenObj){
                return a.output;
            }
        }
     return null;
    }
    public bool hasObjFrying(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in fryingSO){
            if(a.input==InputCuttingKitchenObj){
                return true;
            }
    }
    return false;
    }

    public FryingSO getFryingKitchenObjSO(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in fryingSO){
            if(a.input==InputCuttingKitchenObj){
                return a;
            }
    }
    return null;
    }

    public BurnSO getBurningKitchenObjSO(KitchenObjectSO InputKitchenObj){
        foreach(var a in burnSO){
            if(a.input==InputKitchenObj){
                return a;
            }
        }
        return null;
    }
}
