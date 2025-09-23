using UnityEngine;
using System;

/// <summary>
/// �ړ���Ԃ�\���񋓑�
/// </summary>
public enum MoveStatus
{
    None,       // �������Ă��Ȃ�
    Walking,    // �����Ă���
    Sprinting,  // �_�b�V�����Ă���
    Crouching,  // ���Ⴊ��ł���
}

/// <summary>
/// �U����Ԃ�\���񋓑�
/// </summary>
public enum AttackStatus
{
    None,   // �U�����Ă��Ȃ�
    normal, // �ʏ�U��
    small,  // ���U��
    big,    // ��U��
}

/// <summary>
/// �h���Ԃ�\���񋓑�
/// </summary>
public enum DffenceStatus
{
    None,   // �h�䂵�Ă��Ȃ�
    normal, // �ʏ�h��
    small,  // ��h��
    big,    // ���h��
}

/// <summary>
/// �v���C���[��L�����N�^�[�̏�Ԃ��Ǘ�����N���X�B
/// �ړ��E�U���E�h��̊e��Ԃ�ێ����A
/// �O������͓ǂݎ���p�ŃA�N�Z�X�\�ɂ���B
/// </summary>
public class Status : MonoBehaviour
{
    /// <summary>
    /// ���݂̈ړ����
    /// </summary>
    public MoveStatus CurrentMoveStatus { get; private set; } = MoveStatus.None;

    /// <summary>
    /// ���݂̍U�����
    /// </summary>
    public AttackStatus CurrentAttackStatus { get; private set; } = AttackStatus.None;

    /// <summary>
    /// ���݂̖h����
    /// </summary>
    public DffenceStatus CurrentDffenceStatus { get; private set; } = DffenceStatus.None;

    /// <summary>
    /// ���͂��ꂽ�ړ��x�N�g���i�O������͓ǂݎ���p�j
    /// </summary>
    private Vector2 _moveInput = Vector2.zero;
    public Vector2 MoveInput => _moveInput;

    /// <summary>
    /// �ړ���Ԃ�ݒ肷��
    /// </summary>
    /// <param name="moveStatus">�ݒ肷��ړ����</param>
    public void MoveSetStatus(MoveStatus moveStatus)
    {
        if (CurrentMoveStatus == moveStatus) return;
        CurrentMoveStatus = moveStatus;
    }

    /// <summary>
    /// �U����Ԃ�ݒ肷��
    /// </summary>
    /// <param name="attackStatus">�ݒ肷��U�����</param>
    public void AttackSetStatus(AttackStatus attackStatus)
    {
        if (CurrentAttackStatus == attackStatus) return;
        CurrentAttackStatus = attackStatus;
    }

    /// <summary>
    /// �h���Ԃ�ݒ肷��
    /// </summary>
    /// <param name="dffenceStatus">�ݒ肷��h����</param>
    public void DffenceSetStatus(DffenceStatus dffenceStatus)
    {
        if (CurrentDffenceStatus == dffenceStatus) return;
        CurrentDffenceStatus = dffenceStatus;
    }

    public void SetMoveInput(Vector2 input)
    {
        _moveInput = input;
        UpdateMoveStatusFromInput();
    }

    private void UpdateMoveStatusFromInput()
    {
        if (_moveInput == Vector2.zero)
        {
            MoveSetStatus(MoveStatus.None);
        }
        else if (CurrentMoveStatus == MoveStatus.None)
        {
            MoveSetStatus(MoveStatus.Walking);
        }
    }
}
