using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ItemDatabase itemDatabase; // データベースを参照

    public void OpenInventory()
    {
        foreach (var slot in player.Inventory.slots)
        {
            // itemIdからItemDataを探す
            ItemData data = itemDatabase.GetItemById(slot.itemId);

            if (data != null)
            {
                Debug.Log($"{data.name} x{slot.count}");
                // data.icon や data.description を使ってUI更新できる
            }
            else
            {
                Debug.LogWarning($"ID {slot.itemId} に対応するアイテムが見つかりません");
            }
        }
    }
}
