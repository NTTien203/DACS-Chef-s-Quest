using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
     IKitchenObjParent kitchenObjParent;
    public KitchenObjectSO GetKitchenObjectSO()
   {
        return kitchenObjectSO;
   }

   public IKitchenObjParent GetKitchenObjParent(){
     return kitchenObjParent;
   }

   public void setkitchenObjParent(IKitchenObjParent kitchenObjParent){
     if(this.kitchenObjParent!=null){
          this.kitchenObjParent.ClearKitchenObj();
     }
     this.kitchenObjParent =kitchenObjParent;
     kitchenObjParent.SetKitchenObj(this);
     transform.parent=kitchenObjParent.GetKitchenObjFollowTransform();
     transform.localPosition=Vector3.zero;
   }

   
}
