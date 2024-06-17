using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenceManage : MonoBehaviour
{
    public static scenceManage Instance { get;set;}

    private void Awake() {
        Instance=this;
    }
    public void LoadFirstScence(){
         SceneManager.LoadScene("Scence1");
    }
   public void LoadSecondScence(){
        SceneManager.LoadScene("Scence2");
   }
   public void LoadThirdScence(){
        SceneManager.LoadScene("Scence3");
   }
   public void LoadTutorialScence(){
     SceneManager.LoadScene("Tutorial");
   }
    public void LoadStartScence(){
     SceneManager.LoadScene("StartScence");
   }

}
