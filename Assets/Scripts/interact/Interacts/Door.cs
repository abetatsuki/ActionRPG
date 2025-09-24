using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    private bool _isOpened = false;

    public void Interact()
    {
        if (_isOpened) return;
        _isOpened = true;
        Debug.Log("ƒhƒA‚ðŠJ‚¯‚Ü‚µ‚½");
    }
}
