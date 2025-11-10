using UnityEngine;

public class SwordAttack : Item, IAttackable
{
    [SerializeField] private Animator _animator;

    public void Attack()
    {
        Debug.Log("yes");
        _animator.SetTrigger("Attack1");
    }
}
