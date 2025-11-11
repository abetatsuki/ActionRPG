using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<ItemData> _inventory = new List<ItemData>();
    public List<ItemData> Inventory => _inventory;

    public void AddItem(ItemData itemdata) { { _inventory.Add(itemdata); Debug.Log("InInventory"); } }
    public void RemoveItem(ItemData itemdata) { _inventory.Remove(itemdata); }

    public void  GetInventory()
    {
        foreach (ItemData itemdata in _inventory)
        {
            Debug.Log(itemdata.Name);
        }
    }
    

}
