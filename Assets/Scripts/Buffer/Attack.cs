using UnityEngine;



public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private PlayerInputNotifier _notifier;
    private IAttackable attackable;
    private void OnEnable()
    {
        _notifier.OnInteract += TryAttack;
    }

    private void OnDisable()
    {
        _notifier.OnInteract -= TryAttack;
    }

    private void TryAttack()
    {
        attackable = GetComponent<IAttackable>();
        attackable.Attack();
    }
}
