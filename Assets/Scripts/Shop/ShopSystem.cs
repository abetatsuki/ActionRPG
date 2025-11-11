using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField]Itempp itempp;

    public bool MoneyAffrod(int money)
    {
        return itempp.price >= money;
    }
}
