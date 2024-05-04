using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
  
   public override void Interact(Player player){
      if(!hasKitchenObj()){
         if(player.hasKitchenObj()){
            player.GetKitchenObj().setkitchenObjParent(this);
         }
         
      }else{
         if(player.hasKitchenObj()){
           if(player.GetKitchenObj().TryGetPlate(out PlateKitchenObj plateKitchenObj)){
            if(plateKitchenObj.TryAddIngredient(GetKitchenObj().GetKitchenObjectSO())){
               GetKitchenObj().DestroyKitchenObj();
            }
           }else if(GetKitchenObj().TryGetPlate(out plateKitchenObj)){
            if(plateKitchenObj.TryAddIngredient(player.GetKitchenObj().GetKitchenObjectSO())){
               player.GetKitchenObj().DestroyKitchenObj();
            }
           }
         }

         if(!player.hasKitchenObj()){
            GetKitchenObj().setkitchenObjParent(player);
         }
      }
      
   }
  
  

}
