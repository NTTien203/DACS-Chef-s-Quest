using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class BarUi : MonoBehaviour
{
    [SerializeField]GameObject gameObjectHasProgress;
    IHasProgress hasProgress;
    [SerializeField] Image imagebar;

    private void Start() {
        hasProgress=gameObjectHasProgress.GetComponent<IHasProgress>();
         hasProgress.OnProgress += hasProgress_OnProgress;
        imagebar.fillAmount=0f;
        hide();
    }

    private void hasProgress_OnProgress(object sender, IHasProgress.onProgressEventArgs e)
    {
        imagebar.fillAmount=e.progress;
        if(e.progress==0|| e.progress==1){
            hide();
        }else{
            show();
        }
    }


    void show(){
        gameObject.SetActive(true);
    }

    void hide(){
        gameObject.SetActive(false);
    }
}
