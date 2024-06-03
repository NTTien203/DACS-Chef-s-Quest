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
   public void LoadNextScence(){
        SceneManager.LoadScene("Scence2");
   }
   public void LoadTutorialScence(){
     SceneManager.LoadScene("Tutorial");
   }
    public void LoadStartScence(){
     SceneManager.LoadScene("StartScence");
   }

}
