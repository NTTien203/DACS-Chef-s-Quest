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
   public void LoadNextScence(){
        SceneManager.LoadScene("Scence2");
   }

}
