using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ItemDatabase itemDatabase; // �f�[�^�x�[�X���Q��

    public void OpenInventory()
    {
        foreach (var slot in player.Inventory.slots)
        {
            // itemId����ItemData��T��
            ItemData data = itemDatabase.GetItemById(slot.itemId);

            if (data != null)
            {
                Debug.Log($"{data.name} x{slot.count}");
                // data.icon �� data.description ���g����UI�X�V�ł���
            }
            else
            {
                Debug.LogWarning($"ID {slot.itemId} �ɑΉ�����A�C�e����������܂���");
            }
        }
    }
}
