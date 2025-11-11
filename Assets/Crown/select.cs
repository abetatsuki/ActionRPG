using UnityEngine;


public class select : MonoBehaviour
{
  [SerializeField] private  ItemDataBase _itemDataBase;

    public void Select(int i)
    {
        _itemDataBase.GetItemData(i);
        Debug.Log(_itemDataBase.GetItemData(i));
       
    }
}
