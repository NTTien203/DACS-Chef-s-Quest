using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    [SerializeField] private AudioRefSO audioRefSO;
    

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
        PlaySound(audioRefSO.trash,trashCounter.transform.position);
    }

    private void BaseCounter_OnOjbPutDown(object sender, EventArgs e)
    {
        BaseCounter baseCounter= sender as BaseCounter;
        PlaySound(audioRefSO.objectDrop,baseCounter.transform.position);
    }

    private void Player_OnPickUpSomething(object sender, EventArgs e)
    {
        Player player=Player.instance;
        PlaySound(audioRefSO.objectPickup,player.transform.position);
    }

    private void CuttingKitchenobj_OnAnyCut(object sender, EventArgs e)
    {
        CuttingKitchenObj cuttingKitchenObj= sender as CuttingKitchenObj;
        PlaySound(audioRefSO.chop,cuttingKitchenObj.transform.position); 
    }

    private void DeliveryManage_OnRecipeSuccess(object sender, EventArgs e)
    {
          DeliveryCounter deliveryCounter= DeliveryCounter.instance;
       PlaySound(audioRefSO.deliverySuccess,deliveryCounter.transform.position);
    }

    private void DeliveryManage_OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter= DeliveryCounter.instance;
        PlaySound(audioRefSO.deliveryFail,deliveryCounter.transform.position);
    }
    private void PlaySound(AudioClip[] audioClipArray, Vector3 position,float volume=1000f){
        AudioSource.PlayClipAtPoint(audioClipArray[UnityEngine.Random.Range(0,audioClipArray.Length)],position,volume);
   }
    private void PlaySound(AudioClip audioClip, Vector3 position,float volume=1f){
        AudioSource.PlayClipAtPoint(audioClip,position,volume);
   }
   public void PlayFootstepsSound(Vector3 position, float volume)
    {
        PlaySound(audioRefSO.footStep, position,volume);
    }
}
