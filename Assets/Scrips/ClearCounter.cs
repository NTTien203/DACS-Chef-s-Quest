using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjParent
{
   [SerializeField] KitchenObjectSO objTranform;
   [SerializeField] Transform counterTopPoint;
   KitchenObject kitchenObject;

 
   
   public void Interact(Player player){
      if(kitchenObject == null){
         GameObject kitchenObj=Instantiate(objTranform.prefab, counterTopPoint);
         kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(this);
      }else{
         kitchenObject.setkitchenObjParent(player);
      }
      
   }
   //Interface IKitchenObjParent
   public Transform GetKitchenObjFollowTransform(){
      return counterTopPoint;
   }

   public void ClearKitchenObj(){
       kitchenObject=null;
   }

   public KitchenObject GetKitchenObj(){
      return kitchenObject;
   }

   public void SetKitchenObj(KitchenObject kitchenObject){
      this.kitchenObject=kitchenObject;
   }

   public bool hasKitchenObj(){
      return kitchenObject!=null;
   }

}
