using UnityEngine;

public class Player : StatusBase
{

    protected override void Die()
    {
        Debug.Log("プレイヤー死亡 => ゲームオーバー");
    }
}
