using Unity.VisualScripting;
using UnityEngine;

public class Player : StatusBase
{

    protected override void Die()
    {
        Debug.Log("プレイヤー死亡 => ゲームオーバー");
    }
    public void ShopCheck(int price)
    {
        this.money -= price;
    }

}
