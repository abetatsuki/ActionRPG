using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Status _status;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _basespeed = 3f;
    [SerializeField] private float _sprintspeed = 6f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _cameraTransform;

    [SerializeField] private float _currentSpeed; 

    private bool _isSprinting = false;


    private void OnEnable()
    {
        _notifier.OnMove += _status.SetMoveInput;
        _notifier.OnSprint += SetSprint;
    }

    private void OnDisable()
    {
        _notifier.OnMove -= _status.SetMoveInput;
        _notifier.OnSprint -= SetSprint;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void SetSprint(bool sprinting)
    {
        _isSprinting = sprinting;
    }

    private void MovePlayer()
    {
        Vector2 input = _status.MoveInput;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * input.y + right * input.x).normalized;

        if (input.magnitude > 0)
        {
            _currentSpeed = _isSprinting ? _sprintspeed : _basespeed;
        }
        else
        {
            _currentSpeed = 0f;
        }


        Vector3 velocity = moveDir * _currentSpeed;
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);


  
        float normalizedSpeed = _currentSpeed / _sprintspeed; // 最大速度で割る

        _animator.SetFloat("Speed", normalizedSpeed);

    }
}
