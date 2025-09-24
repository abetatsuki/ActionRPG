using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    public void StartNewGame()
    {
        player.InitializeForNewGame();
        // ここでシーンをロードしたりプレイヤー初期化したりする
    }
}
