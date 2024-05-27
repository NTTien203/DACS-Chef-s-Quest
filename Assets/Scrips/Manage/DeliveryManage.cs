using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManage : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeFailed;
    public event EventHandler OnRecipeSuccess;
    [SerializeField] RecipeListSO recipeListSO;
    private int waitingRecipesMax = 4;
    List<RecipeSO> waitingRecipeSOlist;
    float spawnRecipeTimer;
    float spawnRecipeMax=5f;
     int RecipeSuccessCount=0;

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
            RecipeSO waitingRecipeSO= recipeListSO.ListRecipeSO[UnityEngine.Random.Range(0,recipeListSO.ListRecipeSO.Count)];
            if(waitingRecipeSOlist.Count<waitingRecipesMax){
                Debug.Log(waitingRecipeSO);
                waitingRecipeSOlist.Add(waitingRecipeSO);
                OnRecipeSpawned?.Invoke(this,EventArgs.Empty);
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
                    RecipeSuccessCount++;
                    waitingRecipeSOlist.RemoveAt(i);
                    OnRecipeCompleted?.Invoke(this,EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this,EventArgs.Empty);
                    Debug.Log("success");
                    return;
                    
                }
            }

        }

            OnRecipeFailed?.Invoke(this,EventArgs.Empty);
            Debug.Log("fail");
    }
    public List<RecipeSO> getWaitingList(){
        return waitingRecipeSOlist;
    }

    public int getRecipeCompleteCount(){
        return RecipeSuccessCount;
    }
}





