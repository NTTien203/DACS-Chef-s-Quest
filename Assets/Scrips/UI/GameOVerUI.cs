using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOVerUI : MonoBehaviour
{
    [SerializeField ]TextMeshProUGUI RecipeSuccessCount;
    [SerializeField] TextMeshProUGUI TextState;
    [SerializeField] int TargetScore;
    void Start()
    {
        GameManage.Instance.OnStateChange+=GameManage_OnStateChange;
        hide();
    }

    private void GameManage_OnStateChange(object sender, EventArgs e)
    {
        if(GameManage.Instance.isGameOver()){
            if(DeliveryManage.instance.getRecipeCompleteCount()>=TargetScore){
                TextState.text="Congratulation";
                RecipeSuccessCount.text=DeliveryManage.instance.getRecipeCompleteCount().ToString();
                scenceManage.Instance.Invoke("LoadNextScence", 5f);
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
