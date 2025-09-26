using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    private GameObject _maincm;
    private GameObject _subcm;
   

    private void Start()
    {
        _maincm = GameObject.Find("MainCamera");
        _subcm = GameObject.Find("SubCamera");

        _subcm.SetActive(false);

       

    }
    private void OnEnable()
    {
        _notifier.OnCamera += CameraSwitcher;
    }

    private void OnDisable()
    {
        _notifier.OnCamera -= CameraSwitcher;
    }

    public void CameraSwitcher(bool isPressed) //ÉJÉÅÉâÇ™2ë‰Ç»ÇÁÇ±ÇÍÇ≈ÇÊÇµ
    {
        Debug.Log("CAMERAON");
      _maincm.SetActive(!isPressed);
      _subcm?.SetActive(isPressed);
    }
}
