using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataBase",menuName ="Item DataBase",order =0)]
public class ItemDataBase : ScriptableObject

{
    [SerializeField] ItemData[] _itemDatas;
    public ItemData[] ItemDatas => _itemDatas;
    public ItemData GetItemData(int index)
    {
        if (index < 0 || index >= _itemDatas.Length)
        {
            Debug.LogWarning($"ItemDataBase: index {index} ‚Í”ÍˆÍŠO‚Å‚·B");
            return null;
        }

        return _itemDatas[index];
    }
}
