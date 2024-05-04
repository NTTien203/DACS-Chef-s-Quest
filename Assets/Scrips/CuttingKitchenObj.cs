using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CuttingKitchenObj : BaseCounter,IHasProgress
{
    public event EventHandler <IHasProgress.onProgressEventArgs> OnProgress;
    
     [SerializeField] CuttingRecipeSO[] cuttingKitchenObj;
    int cuttingProgress=0;
    public override void Interact(Player player){
      if(!hasKitchenObj()){
         if(player.hasKitchenObj()){
            if(hasObjCutting(player.GetKitchenObj().GetKitchenObjectSO())){
                player.GetKitchenObj().setkitchenObjParent(this);
                OnProgress?.Invoke(this, new IHasProgress.onProgressEventArgs{
                    progress=cuttingProgress/getCuttingKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).CuttingTimes
                });
            }
         }
         
      }else{
         if(!player.hasKitchenObj()){
            GetKitchenObj().setkitchenObjParent(player);
         }if(player.hasKitchenObj()){
             if(player.GetKitchenObj().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
            if(plateKitchenObj.TryAddIngredient(GetKitchenObj().GetKitchenObjectSO())){
               GetKitchenObj().DestroyKitchenObj();
            }
           }
         }
      }
      
   }

    public override void InteractAlternate(Player player)
    {
        if(hasKitchenObj()){
            cuttingProgress++;
            KitchenObjectSO outputKitchenObj=getOutputKitchenObj(GetKitchenObj().GetKitchenObjectSO());
            OnProgress?.Invoke(this, new IHasProgress.onProgressEventArgs{
                    progress=(float)cuttingProgress/getCuttingKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).CuttingTimes
                });
            if(getCuttingKitchenObjSO(GetKitchenObj().GetKitchenObjectSO()).CuttingTimes<=cuttingProgress){
                
                cuttingProgress=0;
                GetKitchenObj().DestroyKitchenObj();
                GameObject kitchenObj=Instantiate(outputKitchenObj.prefab);
                kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(this);
               
            }else{
                
            }
            
        }else{
            
        }
    }

    public KitchenObjectSO getOutputKitchenObj(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in cuttingKitchenObj){
            if(a.input==InputCuttingKitchenObj){
                return a.output;
            }
    }
    return null;
    }

    public bool hasObjCutting(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in cuttingKitchenObj){
            if(a.input==InputCuttingKitchenObj){
                return true;
            }
    }
    return false;
    }

    public CuttingRecipeSO getCuttingKitchenObjSO(KitchenObjectSO InputCuttingKitchenObj){
        foreach( var a in cuttingKitchenObj){
            if(a.input==InputCuttingKitchenObj){
                return a;
            }
    }
    return null;
    }
}
