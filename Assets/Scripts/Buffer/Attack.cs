using UnityEngine;



public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    [SerializeField]private PickUpItem PickUpItem;
    private IAttackable attackable;
    [SerializeField]GameObject attackableGameObject;
    private void OnEnable()
    {
        _notifier.OnAttack += TryAttack;
    }

    private void OnDisable()
    {
        _notifier.OnAttack -= TryAttack;
    }

    private void TryAttack()
    {
       // PickUpItem.PickUpWeapon(attackableGameObject);
        PickUpItem.Attack();
    }
}
