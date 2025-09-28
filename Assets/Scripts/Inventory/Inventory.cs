using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemBase> items = new List<ItemBase>();

    public void AddItem(ItemBase item)
    {
        items.Add(item);
        Debug.Log($"{item.GetItemName()} ���C���x���g���ɒǉ����܂���");
    }

    public List<ItemBase> GetItems() => items;

    public void RemoveItem(ItemBase item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.GetItemName() + " ���C���x���g������폜�I");
        }
    }
}
