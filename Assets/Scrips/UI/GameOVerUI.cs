using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOVerUI : MonoBehaviour
{
    [SerializeField ]TextMeshProUGUI RecipeSuccessCount;
    [SerializeField] TextMeshProUGUI TextState;
    [SerializeField] public int TargetScore;
    [SerializeField] Button button;
    void Start()
    {
        GameManage.Instance.OnStateChange+=GameManage_OnStateChange;
         button.gameObject.SetActive(false);
        hide();
    }

    private void GameManage_OnStateChange(object sender, EventArgs e)
    {
        if(GameManage.Instance.isGameOver()){
            if(DeliveryManage.instance.getRecipeCompleteCount()>=TargetScore){
                if(SceneManager.GetActiveScene().name=="Scence1"){
                     TextState.text="Congratulation";
                    RecipeSuccessCount.text=DeliveryManage.instance.getRecipeCompleteCount().ToString();
                    scenceManage.Instance.Invoke("LoadSecondScence", 5f);
                }else if(SceneManager.GetActiveScene().name=="Scence2"){
                    TextState.text="Congratulation";
                    RecipeSuccessCount.text=DeliveryManage.instance.getRecipeCompleteCount().ToString();
                    scenceManage.Instance.Invoke("LoadThirdScence", 5f);
                }else if(SceneManager.GetActiveScene().name=="Scence3"){
                    TextState.text="Congratulation";
                    RecipeSuccessCount.text=DeliveryManage.instance.getRecipeCompleteCount().ToString();
                    button.gameObject.SetActive(true);
                }
            }else{
                button.gameObject.SetActive(true);
            }
            
            show();
            RecipeSuccessCount.text=DeliveryManage.instance.getRecipeCompleteCount().ToString();
        }else{
            hide();
        }
    }

    private void show(){
        gameObject.SetActive(true);
    }
    private void hide(){
        gameObject.SetActive(false);
    }
    // Update is called once per frame
   
}
