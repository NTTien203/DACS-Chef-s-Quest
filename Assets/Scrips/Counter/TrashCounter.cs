using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnObjTrashed;
    public override void Interact(Player player){
        if(player.hasKitchenObj()){
            player.GetKitchenObj().DestroyKitchenObj();
            OnObjTrashed?.Invoke(this,EventArgs.Empty);
        }
    }               
}
