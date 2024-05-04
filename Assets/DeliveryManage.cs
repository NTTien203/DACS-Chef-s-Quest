using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class DeliveryManage : MonoBehaviour
{
    [SerializeField] RecipeListSO recipeListSO;
    private int waitingRecipesMax = 4;
    List<RecipeSO> waitingRecipeSOlist;
    float spawnRecipeTimer;
    float spawnRecipeMax=5f;

    public static DeliveryManage instance 
         { get; set; }
    private void Awake() {
         instance=this; 
        waitingRecipeSOlist = new List<RecipeSO>();
    }

    private void Update() {
        spawnRecipeTimer-=Time.deltaTime;
        if(spawnRecipeTimer<=0){
            spawnRecipeTimer=spawnRecipeMax;
            RecipeSO waitingRecipeSO= recipeListSO.ListRecipeSO[Random.Range(0,recipeListSO.ListRecipeSO.Count)];
            if(waitingRecipeSOlist.Count<waitingRecipesMax){
                Debug.Log(waitingRecipeSO);
                waitingRecipeSOlist.Add(waitingRecipeSO);
            }
            
        }
    }

    public void DeliveryRecipe(PlateKitchenObj plateKitchenObj){
        for(int i=0;i<waitingRecipeSOlist.Count;i++){
            RecipeSO waitingRecipeSO= waitingRecipeSOlist[i];
            if(waitingRecipeSO.ListKitchenObjSO.Count==plateKitchenObj.kitchenObjSOList.Count){
                bool plateMatchesRecipe=true;
                foreach(KitchenObjectSO kitchenObjectSO in waitingRecipeSO.ListKitchenObjSO){
                     bool ingredientFound = false;
                    foreach(KitchenObjectSO plateKitchenObjSO in plateKitchenObj.kitchenObjSOList){
                        if(kitchenObjectSO==plateKitchenObjSO){
                            ingredientFound=true;
                            break;
                        }
                    }
                    if(!ingredientFound){
                       plateMatchesRecipe=false;
                    }
                }
                if(plateMatchesRecipe){
                    waitingRecipeSOlist.RemoveAt(i);
                    Debug.Log("success");
                }else{
                    Debug.Log("fail");
                }
            }
        }
    }
}





