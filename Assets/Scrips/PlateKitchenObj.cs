using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObj : KitchenObject
{
    public event EventHandler<onIngredientAddedArgs> onIngredientAdded;
    public class onIngredientAddedArgs: EventArgs{
        public KitchenObjectSO kitchenObjectSO;
    }
    
    [SerializeField]  List<KitchenObjectSO> validKitchenObj;
    public List<KitchenObjectSO> kitchenObjSOList;
    private void Awake() {
        kitchenObjSOList=new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO){
        if(!validKitchenObj.Contains(kitchenObjectSO)){
            return false;
        }
        if(!kitchenObjSOList.Contains(kitchenObjectSO)){
            kitchenObjSOList.Add(kitchenObjectSO);
            onIngredientAdded?.Invoke(this, new onIngredientAddedArgs{
                kitchenObjectSO=kitchenObjectSO,
            });
            return true;
        }else{
            return false;
        }
        
        
    }

    
}
