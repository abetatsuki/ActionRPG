using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<ItemBase> items = new List<ItemBase>();

    public void AddItem(ItemBase item)
    {
        items.Add(item);
        Debug.Log($"{item.GetItemName()} をインベントリに追加しました");
    }

    public List<ItemBase> GetItems() => items;

    public void RemoveItem(ItemBase item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.GetItemName() + " をインベントリから削除！");
        }
    }
}
