using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeliveryManageSingleUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI RecipeNameText;
    public void setRecipeName(RecipeSO recipeSO){
        RecipeNameText.text=recipeSO.name;
    }
}
