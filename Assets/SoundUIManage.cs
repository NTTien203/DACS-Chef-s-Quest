using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUIManage : MonoBehaviour
{
    public void hide(){
        this.gameObject.SetActive(false);
    }

    public void show(){
        this.gameObject.SetActive(true);
    }
}
