using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log($"{item.GetItemName()} をインベントリに追加しました");
    }

    public List<Item> GetItems() => items;

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.GetItemName() + " をインベントリから削除！");
        }
    }
}
