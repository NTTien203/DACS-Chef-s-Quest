using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContainPlate : BaseCounter
{
   [SerializeField] KitchenObjectSO objectSO;
   [SerializeField] TMP_Text text;
    public static int countPlate=4;
   
    private void Update() {
        text.text=countPlate.ToString();
    }
    public override void Interact(Player player){
        if(!player.hasKitchenObj()&& countPlate>0){
          GameObject kitchenObj=Instantiate(objectSO.prefab);
         kitchenObj.GetComponent<KitchenObject>().setkitchenObjParent(player);
         countPlate--;
        
        }
   }
}
