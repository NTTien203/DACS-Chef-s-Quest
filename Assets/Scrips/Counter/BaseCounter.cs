using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour,IKitchenObjParent
{
    [SerializeField] Transform counterTopPoint;
    KitchenObject kitchenObject;
    public virtual void Interact(Player player){

    }
   public virtual void InteractAlternate(Player player){

    }
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
