using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public int id;
    public string name;
    public string description;
    public GameObject item;
    public int power;
}

[CreateAssetMenu(menuName = "Database/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<ItemData> items;

    public ItemData GetItemById(int id)
    {
        return items.Find(item => item.id == id);
    }
}
