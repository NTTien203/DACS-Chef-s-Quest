using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MusicManage : MonoBehaviour
{
    AudioSource musicManage;
    [SerializeField]Button OffMusicButton;
    [SerializeField]Button OnMusicButton;
    [SerializeField]Slider slider;

     public static MusicManage Instance {get; private set;}
    // Start is called before the first frame update
    void Awake()
    {
        
        musicManage=GetComponent<AudioSource>();
        Instance=this;
      // DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    public void muteMusic(){
        OffMusicButton.gameObject.SetActive(false);
        OnMusicButton.gameObject.SetActive(true);
        musicManage.mute=true;
    }
    public void OnMusic(){
        OffMusicButton.gameObject.SetActive(true);
        OnMusicButton.gameObject.SetActive(false);
        musicManage.mute=false;
    }
   private void Update() {
       musicManage.volume=slider.value;
   }
    public void ScencePersistence(){
        Destroy(gameObject);
    }

  
}
