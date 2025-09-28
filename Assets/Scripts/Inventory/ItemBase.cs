using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IPickupable, IInteractable
{
    [SerializeField] protected string itemName;   // �q�N���X�Őݒ�
    [SerializeField] protected Sprite icon;       // �q�N���X�Őݒ�

    public string GetItemName() => itemName;
    public Sprite GetIcon() => icon;
    private Collider _collider;

    protected virtual void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    public void SetColliderActive(bool active)
    {
        if (_collider != null)
            _collider.enabled = active;
    }
    public void Interact(GameObject interactor)
    {
        Debug.Log("seikou");
        // �C���x���g���擾
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(this);
            Debug.Log($"{GetItemName()} ���E�����I");
        }

        // �����p�Ȃ�PickUpItem���Ă�
        var pickUpHandler = interactor.GetComponent<PickUpItem>();
        if (pickUpHandler != null && this is IAttackable)
        {
            pickUpHandler.EquipWeapon(this.gameObject);
            
        }
        else
        {
            gameObject.SetActive(false);
        }

      
    }

}
