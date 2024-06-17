using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
public class SoundManage : MonoBehaviour
{
    
    [SerializeField]Button OffMusicButton;
    [SerializeField]Button OnMusicButton;
    [SerializeField]Slider slider;
     public float volume=1f;
     bool mute=false;
    [SerializeField] private AudioRefSO audioRefSO;
    

    //singleton pattern
     public static SoundManage Instance {get; private set;}

     private void Awake() {
        Instance=this;
     }
    private void Start() {
        DeliveryManage.instance.OnRecipeFailed+=DeliveryManage_OnRecipeFailed;
        DeliveryManage.instance.OnRecipeSuccess+=DeliveryManage_OnRecipeSuccess;
        CuttingKitchenObj.onAnyCut+=CuttingKitchenobj_OnAnyCut;
        Player.instance.OnPickUpSomething+=Player_OnPickUpSomething;
        BaseCounter.OnOjbPutDown+=BaseCounter_OnOjbPutDown;
        TrashCounter.OnObjTrashed+=TrashCounter_OnObjTrashed;
    }

    private void TrashCounter_OnObjTrashed(object sender, EventArgs e)
    {
        TrashCounter trashCounter=sender as TrashCounter;
        PlaySound(audioRefSO.trash,trashCounter.transform.position,volume);
    }

    private void BaseCounter_OnOjbPutDown(object sender, EventArgs e)
    {
        BaseCounter baseCounter= sender as BaseCounter;
        PlaySound(audioRefSO.objectDrop,baseCounter.transform.position,volume);
    }

    private void Player_OnPickUpSomething(object sender, EventArgs e)
    {
        Player player=Player.instance;
        PlaySound(audioRefSO.objectPickup,player.transform.position,volume);
    }

    private void CuttingKitchenobj_OnAnyCut(object sender, EventArgs e)
    {
        CuttingKitchenObj cuttingKitchenObj= sender as CuttingKitchenObj;
        PlaySound(audioRefSO.chop,cuttingKitchenObj.transform.position,volume); 
    }

    private void DeliveryManage_OnRecipeSuccess(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter= DeliveryCounter.instance;
       PlaySound(audioRefSO.deliverySuccess,deliveryCounter.transform.position,volume);
    }

    private void DeliveryManage_OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter= DeliveryCounter.instance;
        PlaySound(audioRefSO.deliveryFail,deliveryCounter.transform.position,volume);
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position,float volume){
        AudioSource.PlayClipAtPoint(audioClipArray[UnityEngine.Random.Range(0,audioClipArray.Length)],position,volume);
   }
   
   public void PlayFootstepsSound(Vector3 position, float volume)
    {
        PlaySound(audioRefSO.footStep, position,volume);
    }
    public void muteMusic(){
        mute=true;
        OffMusicButton.gameObject.SetActive(false);
        OnMusicButton.gameObject.SetActive(true);
        volume=0f;
    }
    public void OnMusic(){
        OffMusicButton.gameObject.SetActive(true);
        OnMusicButton.gameObject.SetActive(false);
        volume=0.5f;
    }
    private void Update() {
        if(!mute){
             volume=slider.value;
        }
       
    }
}
