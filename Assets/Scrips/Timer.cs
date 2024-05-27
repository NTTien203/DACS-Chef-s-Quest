using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] Image TimerImage;
    private void Update() {
        TimerImage.fillAmount=GameManage.Instance.getGamePlayingTime();
       
    }
}
