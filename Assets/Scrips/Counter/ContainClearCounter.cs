using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainClearCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO objectSO;
   
    public override void Interact(Player player){
        if(!player.hasKitchenObj()){
          GameObject kitchenObj=Instantiate(objectSO.prefab);
         kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(player);
        }
   }
  
}
