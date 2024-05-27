using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public static DeliveryCounter instance{get;set;}

    private void Awake() {
        instance=this;
    }
    public override void Interact(Player player)
    {
        if(player.hasKitchenObj()){
            if(player.GetKitchenObj().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
                DeliveryManage.instance.DeliveryRecipe(plateKitchenObj);
                player.GetKitchenObj().DestroyKitchenObj();
            }
        }
    }
}
