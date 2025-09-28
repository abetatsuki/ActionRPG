using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Transform _player;
    [SerializeField] private float rotationSpeed = 3f;     // マウス回転速度
    [SerializeField] private float followSpeed = 5f;       // カメラ追従速度
    [SerializeField] private float verticalLimit = 80f;    // 上下回転制限
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, -5f); // 後ろ視点用デフォルト
    [SerializeField] private Transform playerBody;         // プレイヤーの体（Yaw回転用）

    private Vector2 lookDelta;
   [SerializeField] private float pitch = 30f;   // 上下回転角（固定）
    private float yaw = 0f;      // 水平回転角

    private void Awake()
    {
        // 初期角度を設定
        Vector3 angles = transform.eulerAngles;
        yaw = angles.y;
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
        // ---- 入力でカメラ回転 ----
        if (lookDelta.sqrMagnitude > 0.0001f)
        {
            yaw += lookDelta.x * rotationSpeed;
            lookDelta = Vector2.zero;
        }


        // カメラの回転を計算
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // プレイヤー位置 + 回転をかけたオフセット
        Vector3 targetPos = _player.position + rotation * offset;

        // カメラを追従
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // プレイヤーの体をYawに追従
        Vector3 bodyEuler = playerBody.eulerAngles;
        bodyEuler.y = yaw;
        playerBody.eulerAngles = bodyEuler;

        // プレイヤーを見る
        transform.LookAt(_player.position + Vector3.up * cameraHeight);
    }
}
