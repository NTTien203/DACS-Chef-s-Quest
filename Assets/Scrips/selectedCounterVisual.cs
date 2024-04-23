using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualSelectedObj;
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.OnSelectedCounterChanged+=Player_OnSelectedCounterChanged;
    }

    

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if(e.selectedCounter==clearCounter){
            show();
        }else{
            hide();
        }
    }

    void show(){
        visualSelectedObj.SetActive(true);
    }

    void hide(){
        visualSelectedObj.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
