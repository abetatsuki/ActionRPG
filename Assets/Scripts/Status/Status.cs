using UnityEngine;
using System;

/// <summary>
/// 移動状態を表す列挙体
/// </summary>
public enum MoveStatus
{
    None,       // 何もしていない
    Walking,    // 歩いている
    Sprinting,  // ダッシュしている
    Crouching,  // しゃがんでいる
}

/// <summary>
/// 攻撃状態を表す列挙体
/// </summary>
public enum AttackStatus
{
    None,   // 攻撃していない
    normal, // 通常攻撃
    small,  // 小攻撃
    big,    // 大攻撃
}

/// <summary>
/// 防御状態を表す列挙体
/// </summary>
public enum DffenceStatus
{
    None,   // 防御していない
    normal, // 通常防御
    small,  // 弱防御
    big,    // 強防御
}

/// <summary>
/// プレイヤーやキャラクターの状態を管理するクラス。
/// 移動・攻撃・防御の各状態を保持し、
/// 外部からは読み取り専用でアクセス可能にする。
/// </summary>
public class Status : MonoBehaviour
{
    /// <summary>
    /// 現在の移動状態
    /// </summary>
    public MoveStatus CurrentMoveStatus { get; private set; } = MoveStatus.None;

    /// <summary>
    /// 現在の攻撃状態
    /// </summary>
    public AttackStatus CurrentAttackStatus { get; private set; } = AttackStatus.None;

    /// <summary>
    /// 現在の防御状態
    /// </summary>
    public DffenceStatus CurrentDffenceStatus { get; private set; } = DffenceStatus.None;

    /// <summary>
    /// 入力された移動ベクトル（外部からは読み取り専用）
    /// </summary>
    private Vector2 _moveInput = Vector2.zero;
    public Vector2 MoveInput => _moveInput;

    /// <summary>
    /// 移動状態を設定する
    /// </summary>
    /// <param name="moveStatus">設定する移動状態</param>
    public void MoveSetStatus(MoveStatus moveStatus)
    {
        if (CurrentMoveStatus == moveStatus) return;
        CurrentMoveStatus = moveStatus;
    }

    /// <summary>
    /// 攻撃状態を設定する
    /// </summary>
    /// <param name="attackStatus">設定する攻撃状態</param>
    public void AttackSetStatus(AttackStatus attackStatus)
    {
        if (CurrentAttackStatus == attackStatus) return;
        CurrentAttackStatus = attackStatus;
    }

    /// <summary>
    /// 防御状態を設定する
    /// </summary>
    /// <param name="dffenceStatus">設定する防御状態</param>
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
