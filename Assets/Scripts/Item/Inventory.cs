using System;
using System.Collections.Generic;

[Serializable]
public class InventorySlot
{
    public int itemId;
    public int count;
}

[Serializable]
public class PlayerInventory
{
    public List<InventorySlot> slots = new List<InventorySlot>();

    public void AddItem(int id, int amount = 1)
    {
        var slot = slots.Find(s => s.itemId == id);
        if (slot != null)
        {
            slot.count += amount;
        }
        else
        {
            slots.Add(new InventorySlot { itemId = id, count = amount });
        }
    }
}
