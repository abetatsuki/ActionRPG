using UnityEngine;

public class Book : MonoBehaviour,IInteractable
{
    private bool _isOpened = false;
    
    public void Interact(GameObject ubteractor)
    {
        if(_isOpened)return;
        _isOpened = true;
       
        Debug.Log("�{��ǂ݂܂���");
    }
}
