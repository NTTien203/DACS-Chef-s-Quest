using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContainPlate : BaseCounter
{
   [SerializeField] KitchenObjectSO objectSO;
   //[SerializeField] TMP_Text text;
    //public static int countPlate=4;
   
    
    public override void Interact(Player player){
        
          GameObject kitchenObj=Instantiate(objectSO.prefab);
         kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(player);
        // countPlate--;
        
        
   }
}
