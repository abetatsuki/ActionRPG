using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Transform _player;
    [SerializeField] private float rotationSpeed = 0.1f;   // マウス回転速度
    [SerializeField] private float followSpeed = 5f;     // カメラ追従速度
    [SerializeField] private float verticalLimit = 80f;  // 上下回転制限
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private Transform playerBody; // プレイヤーの体（Yaw回転用）

    private Vector3 offset;           // プレイヤーとカメラの初期オフセット
    private Vector2 lookDelta;        // マウス入力
    private float pitch = 0f;         // 上下回転角
    private float yaw = 0f;           // 水平回転角

    private void Start()
    {
        offset = transform.position - _player.position;
        offset.y = cameraHeight;

        // 初期角度を設定
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
        pitch = angles.x;
    }

    private void OnEnable()
    {
        _notifier.OnLook += OnLook;
    }

    private void OnDisable()
    {
        _notifier.OnLook -= OnLook;
    }

    private void OnLook(Vector2 delta)
    {
        lookDelta = delta;
    }

    private void LateUpdate()
    {
        // カメラ追従（位置）
        Vector3 targetPos = _player.position + Quaternion.Euler(pitch, yaw, 0f) * offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // マウス入力がある場合のみ回転
        if (lookDelta.sqrMagnitude > 0.0001f)
        {
            yaw += lookDelta.x * rotationSpeed;
            pitch -= lookDelta.y * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -verticalLimit, verticalLimit);

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            transform.rotation = rotation;

            lookDelta = Vector2.zero;
        }

        // プレイヤーの体はカメラの水平角だけに回転
        Vector3 bodyEuler = playerBody.eulerAngles;
        bodyEuler.y = yaw; // カメラのYawに合わせる
        playerBody.eulerAngles = bodyEuler;
    }

}
