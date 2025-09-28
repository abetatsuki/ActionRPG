using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _rayDistance = 10f;
    [SerializeField] private LayerMask _interactableLayer;
    [SerializeField] private PlayerInputNotifier _notifier;

    private void OnEnable()
    {
        _notifier.OnInteract += TryInteract;
    }

    private void OnDisable()
    {
        _notifier.OnInteract -= TryInteract;
    }


    private void TryInteract()
    {
       // Debug.Log("Yes"); // 確認用

        // Ray の可視化（Sceneビューで赤い線として表示される）
        Debug.DrawRay(_camera.transform.position, _camera.transform.forward * _rayDistance, Color.green, 1f);

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, _rayDistance, _interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

}
