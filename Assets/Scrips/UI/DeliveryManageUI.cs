using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManageUI : MonoBehaviour
{
    [SerializeField] Transform container;
    [SerializeField] Transform RecipeTemplate;
    
   
    private void Awake() {
        RecipeTemplate.gameObject.SetActive(false);
    }
     private void Start() {
        DeliveryManage.instance.OnRecipeSpawned+= DeliveryManage_OnRecipeSpawned;
        DeliveryManage.instance.OnRecipeCompleted+= DeliveryManage_OnRecipeCompleted;
        UpdateVisual();

    }

    private void DeliveryManage_OnRecipeCompleted(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void DeliveryManage_OnRecipeSpawned(object sender, EventArgs e)
    {
       UpdateVisual();
    }

    private void UpdateVisual(){
       foreach(Transform child in container){
            if(child== RecipeTemplate){
                continue;
            } 
            Destroy(child.gameObject);  
        }

        foreach(RecipeSO recipeSO in DeliveryManage.instance.getWaitingList()){
            Transform RecipeTramsform=Instantiate(RecipeTemplate,container);
            RecipeTramsform.gameObject.SetActive(true);
            RecipeTramsform.GetComponent<DeliveryManageSingleUI>().setRecipeName(recipeSO);
        }
         
    }
}
