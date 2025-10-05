using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VillagerRange : MonoBehaviour
{
    [SerializeField] private HeadMarkController markController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            markController.ShowMark();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            markController.HideMark();
        }
    }
}
