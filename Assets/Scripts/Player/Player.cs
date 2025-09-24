using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInventory inventory = new PlayerInventory();
    public PlayerInventory Inventory => inventory;
}
