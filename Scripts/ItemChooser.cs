using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChooser : MonoBehaviour
{
   public InventoryItem item;

   public void ChooseItem()
   {
    Debug.Log(item);
   }
}
