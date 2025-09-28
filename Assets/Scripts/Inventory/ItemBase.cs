using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IPickupable, IInteractable
{
    [SerializeField] protected string itemName;   // 子クラスで設定
    [SerializeField] protected Sprite icon;       // 子クラスで設定

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
        // インベントリ取得
        var inventory = interactor.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(this);
            Debug.Log($"{GetItemName()} を拾った！");
        }

        // 装備用ならPickUpItemを呼ぶ
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
