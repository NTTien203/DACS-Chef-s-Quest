using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI text;
    [SerializeField]GameOVerUI gameOVerUI;
    // Start is called before the first frame update
   
    // Update is called once per frame
    private void Start() {
        text.gameObject.SetActive(false);
         GameManage.Instance.OnStateChange+=GameManage_OnStateChange;
    }

    private void GameManage_OnStateChange(object sender, EventArgs e)
    {
        if(GameManage.Instance.IsGamePlaying()){
            text.gameObject.SetActive(true);
            text.text="Số món ăn cần hoàn thành:"+gameOVerUI.TargetScore.ToString();
        }else{
            hide();
        }
    }

    void show(){
        text.gameObject.SetActive(true);
    }
    void hide(){
        text.gameObject.SetActive(true);
    }
}
