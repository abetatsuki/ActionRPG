using UnityEngine;
using UnityEngine.InputSystem;

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

   /// <summary>
   /// イベントが通知されたら処理される
   /// </summary>
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
        Vector2 input = _status.MoveInput; //入力結果を受け取る

        Vector3 forward = _cameraTransform.forward; //カメラの前と右をとる
        Vector3 right = _cameraTransform.right;
        forward.y = 0f; //水平に保つため
        right.y = 0f;
        forward.Normalize();//方向だけもらう
        right.Normalize();

        //斜め入力の時に早くならないように forwardがVector3なのでこの書き方ができる
        //カメラの前方向に対して入力があるので前と後ろを受け取れる
        Vector3 moveDir = (forward * input.y + right * input.x).normalized;

        if (input.magnitude > 0) //動いてないときに走りだす挙動をセーブ
        {
            _currentSpeed = _isSprinting ? _sprintspeed : _basespeed;//走るの判定
            _animator.SetBool("BoolTest",_isSprinting);
        }
        else
        {
            _currentSpeed = 0f;
            _animator.SetBool("BoolTest", false);
        }


        Vector3 velocity = moveDir * _currentSpeed; //スピードをつける
        _rb.linearVelocity = new Vector3(velocity.x, _rb.linearVelocity.y, velocity.z);//移動を実行

        Vector3 localMove = transform.InverseTransformDirection(moveDir) * (_currentSpeed / _sprintspeed);

        float posX = localMove.x; // 左右
        float posY = localMove.z; // 前後（Zを使う）

        _animator.SetFloat("PosX", posX);
        _animator.SetFloat("PosY", posY);

        float normalizedSpeed = _isSprinting ? 1f : (input.magnitude > 0 ? 0.5f : 0f);
        _animator.SetFloat("Speed", normalizedSpeed);


    }
}
