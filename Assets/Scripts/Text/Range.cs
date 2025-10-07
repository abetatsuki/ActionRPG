using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VillagerRange : MonoBehaviour
{
    [SerializeField] private HeadMarkController markController;
    [SerializeField] private PlayerInputNotifier notifier;
    private bool isPlayerInside = false;

    private void OnEnable()
    {
        
       notifier.OnInteract += HandleInteract;
    }

    private void OnDisable()
    {
        notifier.OnInteract -= HandleInteract;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            markController.ShowMark();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            markController.HideMark();
        }
    }
    private void HandleInteract()
    {
        // 範囲内なら会話
        if (isPlayerInside)
        {
            Debug.Log("村人と会話開始！");
            // 会話UIなどの処理
        }
    }
}
