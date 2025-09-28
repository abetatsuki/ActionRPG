using UnityEngine;

public class SwordAttack : MonoBehaviour,IAttackable

{
     [SerializeField] private Animator _animator;
  public  void Attack()
    {
        _animator.SetTrigger("Attack1");

    }
}
