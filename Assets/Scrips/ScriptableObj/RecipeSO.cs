using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class RecipeSO : ScriptableObject
{
   [SerializeField]  public List<KitchenObjectSO> ListKitchenObjSO;
   [SerializeField] string nameObj;
}
