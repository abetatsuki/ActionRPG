using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField] private Transform _player;
    [SerializeField] private float rotationSpeed = 0.1f;   // �}�E�X��]���x
    [SerializeField] private float followSpeed = 5f;     // �J�����Ǐ]���x
    [SerializeField] private float verticalLimit = 80f;  // �㉺��]����
    [SerializeField] private float cameraHeight = 2f;
    [SerializeField] private Transform playerBody; // �v���C���[�̑́iYaw��]�p�j

    private Vector3 offset;           // �v���C���[�ƃJ�����̏����I�t�Z�b�g
    private Vector2 lookDelta;        // �}�E�X����
    private float pitch = 0f;         // �㉺��]�p
    private float yaw = 0f;           // ������]�p

    private void Start()
    {
        offset = transform.position - _player.position;
        offset.y = cameraHeight;

        // �����p�x��ݒ�
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
        // �J�����Ǐ]�i�ʒu�j
        Vector3 targetPos = _player.position + Quaternion.Euler(pitch, yaw, 0f) * offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * followSpeed);

        // �}�E�X���͂�����ꍇ�̂݉�]
        if (lookDelta.sqrMagnitude > 0.0001f)
        {
            yaw += lookDelta.x * rotationSpeed;
            pitch -= lookDelta.y * rotationSpeed;
            pitch = Mathf.Clamp(pitch, -verticalLimit, verticalLimit);

            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            transform.rotation = rotation;

            lookDelta = Vector2.zero;
        }

        // �v���C���[�̑̂̓J�����̐����p�����ɉ�]
        Vector3 bodyEuler = playerBody.eulerAngles;
        bodyEuler.y = yaw; // �J������Yaw�ɍ��킹��
        playerBody.eulerAngles = bodyEuler;
    }

}
