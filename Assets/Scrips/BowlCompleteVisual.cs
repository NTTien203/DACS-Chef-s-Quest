using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCompleteVisual : MonoBehaviour
{
   
    [SerializeField] PlateKitchenObj plateKitchenObj;
    [SerializeField] List<KitchenObject_GameObject> kitchenObject_GameObjects;
    [SerializeField] GameObject fullIngredient;
    [SerializeField] RecipeSO SoupSO;
    [Serializable]
    public struct KitchenObject_GameObject{
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }
    void Start()
    {
        plateKitchenObj.onIngredientAdded+=plateKitchenObj_onIngredientAdded;
        fullIngredient.SetActive(false);
         foreach(KitchenObject_GameObject kitchenObjectSOGameObj in kitchenObject_GameObjects){
            
                kitchenObjectSOGameObj.gameObject.SetActive(false);
        }
    }

    private void plateKitchenObj_onIngredientAdded(object sender, PlateKitchenObj.onIngredientAddedArgs e)
    {
        foreach(KitchenObject_GameObject kitchenObjectSOGameObj in kitchenObject_GameObjects){
            if(kitchenObjectSOGameObj.kitchenObjectSO==e.kitchenObjectSO){
                kitchenObjectSOGameObj.gameObject.SetActive(true);
            }
            if(kitchenObject_GameObjects.Count==SoupSO.ListKitchenObjSO.Count){
                fullIngredient.SetActive(true);
                 foreach(KitchenObject_GameObject b in kitchenObject_GameObjects){
            
                    b.gameObject.SetActive(false);
        }
            }
        }
       
    }

   
}

