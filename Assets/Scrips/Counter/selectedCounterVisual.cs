using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectedCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject visualSelectedObj;
    // Start is called before the first frame update
    void Start()
    {
        Player.instance.OnSelectedCounterChanged+=Player_OnSelectedCounterChanged;
    }

    

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
            if(e.selectedCounter==baseCounter){
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

}
