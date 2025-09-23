using UnityEngine;
using System;

public enum MoveStatus
{
    None,
    Walking,
    Sprinting,
    Crouching,
}
public enum AttackStatus
{
    None,
    normal,
    small,
    big,
}

public enum DffenceStatus
{
    None,
    normal,
    small,
    big,
}

public class Status : MonoBehaviour
{
    public MoveStatus CurrentMoveStatus {  get; private set; } = MoveStatus.None;
    public AttackStatus CurrentAttackStatus { get; private set; } = AttackStatus.None;
    public DffenceStatus CurrentDffenceStatus { get; private set; } = DffenceStatus.None;


}
