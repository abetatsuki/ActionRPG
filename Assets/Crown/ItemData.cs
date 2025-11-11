using UnityEngine;

[CreateAssetMenu( fileName = "ItemData", menuName = "MyGame/Item Data",order = 1)]
public class ItemData : ScriptableObject
{
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private string _name;
 

    public GameObject ItemPrefab => _itemPrefab;
    public string Name => _name;
    
}
