using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
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
