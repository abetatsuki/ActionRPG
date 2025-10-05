using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        // í‚ÉƒJƒƒ‰‚Ì•û‚ğŒü‚­
        transform.LookAt(transform.position + mainCamera.transform.forward);
    }
}
