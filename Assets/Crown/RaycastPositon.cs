using System;
using UnityEngine;

public class RaycastPositon : MonoBehaviour
{
    [SerializeField] private GameObject _gameObj;
    [SerializeField] private bool OnEvent = false;

    private Transform _tf;
    private int layerMask;
    private void Start()
    {
        _tf = _gameObj.GetComponent<Transform>();
         layerMask = ~LayerMask.GetMask("IgnoreRaycast");
    }
    private void Update()
    {
        if (OnEvent)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 100f,layerMask))
            {
  _tf.position = hit.point;
            }
        }
    }



}
