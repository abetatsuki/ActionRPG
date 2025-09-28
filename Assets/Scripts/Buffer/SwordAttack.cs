using UnityEngine;

public class SwordAttack : MonoBehaviour,IAttackable

{
     [SerializeField] private Animator _animator;
  public  void Attack()
    {
        Debug.Log("yes");
        _animator.SetTrigger("Attack1");
    }
}
