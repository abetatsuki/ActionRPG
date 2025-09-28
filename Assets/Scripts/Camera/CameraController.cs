using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Transform _player;
    [SerializeField] private float rotationSpeed = 3f;     // �}�E�X��]���x
    [SerializeField] private float followSpeed = 5f;       // �J�����Ǐ]���x
    [SerializeField] private float verticalLimit = 80f;    // �㉺��]����
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private Vector3 offset = new Vector3(0, 2f, -5f); // ��뎋�_�p�f�t�H���g
    [SerializeField] private Transform playerBody;         // �v���C���[�̑́iYaw��]�p�j

    private Vector2 lookDelta;
   [SerializeField] private float pitch = 30f;   // �㉺��]�p�i�Œ�j
    private float yaw = 0f;      // ������]�p

    private void Awake()
    {
        // �����p�x��ݒ�
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
        // ---- ���͂ŃJ������] ----
        if (lookDelta.sqrMagnitude > 0.0001f)
        {
            yaw += lookDelta.x * rotationSpeed;
            lookDelta = Vector2.zero;
        }


        // �J�����̉�]���v�Z
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        // �v���C���[�ʒu + ��]���������I�t�Z�b�g
        Vector3 targetPos = _player.position + rotation * offset;

        // �J������Ǐ]
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // �v���C���[�̑̂�Yaw�ɒǏ]
        Vector3 bodyEuler = playerBody.eulerAngles;
        bodyEuler.y = yaw;
        playerBody.eulerAngles = bodyEuler;

        // �v���C���[������
        transform.LookAt(_player.position + Vector3.up * cameraHeight);
    }
}
