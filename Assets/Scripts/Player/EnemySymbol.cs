using UnityEngine;

public class EnemySymbol : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�G�ɐڐG�I�퓬�J�n");


        }
    }
}
