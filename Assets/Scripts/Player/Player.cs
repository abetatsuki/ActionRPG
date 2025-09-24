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

    // もしインスペクターで見たい場合、プロパティで公開
    public PlayerInventory Inventory => inventory;
}
