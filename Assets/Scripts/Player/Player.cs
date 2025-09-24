using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory;

    public void InitializeForNewGame()
    {
        inventory = new PlayerInventory();
    }

    public void LoadInventory(PlayerInventory loadedData)
    {
        inventory = loadedData;
    }

    // �����C���X�y�N�^�[�Ō������ꍇ�A�v���p�e�B�Ō��J
    public PlayerInventory Inventory => inventory;
}
