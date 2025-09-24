using UnityEngine;

public class MoveHandler : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Status _status;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _basespeed = 0f;
    [SerializeField] private float _sprintspeed = 0f;

    [SerializeField] private Transform _cameraTransform; // ★追加: カメラの向きを参照する用

    private void OnEnable()
    {
        _notifier.OnMove += _status.SetMoveInput;
    }

    private void OnDisable()
    {
        _notifier.OnMove -= _status.SetMoveInput;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 input = _status.MoveInput;

        // ★ プレイヤーの向きではなくカメラの向きを使う
        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * input.y + right * input.x).normalized;

        float speed = 3f;

        Vector3 velocity = moveDir * speed;
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);
    }
}
