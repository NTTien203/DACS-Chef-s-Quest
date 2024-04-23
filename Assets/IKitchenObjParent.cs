using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjParent 
{
    public Transform GetKitchenObjFollowTransform();
    public void ClearKitchenObj();
    public KitchenObject GetKitchenObj();
    public void SetKitchenObj(KitchenObject kitchenObject);
    public bool hasKitchenObj();
   
}
