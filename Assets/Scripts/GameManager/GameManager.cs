using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;

    public void StartNewGame()
    {
        player.InitializeForNewGame();
        // �����ŃV�[�������[�h������v���C���[�����������肷��
    }
}
