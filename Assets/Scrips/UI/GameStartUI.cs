using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class GameStartUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI CountDown;
   
    void Start()
    {
        GameManage.Instance.OnStateChange+=GameManage_OnStateChange;
    }

    private void GameManage_OnStateChange(object sender, EventArgs e)
    {
        if(GameManage.Instance.IsCountdownToStartActive()){
            show();
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
    void Update()
    {
        CountDown.text=GameManage.Instance.getCountDownToStartTime().ToString("#");
    }
}
