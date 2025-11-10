using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Transform weaponHoldPoint;
    [SerializeField] private Inventory inventory;

    private IAttackable attackable;
    private GameObject currentWeapon;

    /// <summary>
    /// レイキャストなどから拾ったときに呼ぶ
    /// </summary>
    public void PickUp(GameObject itemObj)
    {
        var itemBase = itemObj.GetComponent<Item>();
        if (itemBase == null)
        {
            Debug.Log($"{itemObj.name} は拾えません");
            return;
        }

        // インベントリに追加
        inventory.AddItem(itemBase);

        // 武器なら自動で装備
        if (itemObj.GetComponent<IAttackable>() != null)
        {
            EquipWeapon(itemObj);
        }
        else
        {
            itemObj.SetActive(false);
        } 
    }

    /// <summary>
    /// 武器を装備する
    /// </summary>
    public void EquipWeapon(GameObject weapon)
    {
        // 前の武器をインベントリに戻す
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false); // ワールド上には表示しない
        }

        currentWeapon = weapon;
        currentWeapon.SetActive(true); // 装備中は表示
        

        // GripPoint に合わせて位置・回転を調整
        Transform grip = weapon.transform.Find("GripPoint");
        weapon.transform.SetParent(weaponHoldPoint);

        if (grip != null)
        {
            weapon.transform.localPosition = -grip.localPosition;
            weapon.transform.localRotation = Quaternion.Inverse(grip.localRotation);
        }
        else
        {
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
        }

        attackable = weapon.GetComponent<IAttackable>();
    }

    public void Attack()
    {
        if (attackable != null)
        {
            attackable.Attack();
        }
        else
        {
            Debug.Log("素手");
        }
    }

    /// <summary>
    /// インベントリから装備を切り替える
    /// </summary>
    public void EquipFromInventory(int index)
    {
        var items = inventory.GetItems();
        if (index < 0 || index >= items.Count) return;

        var item = items[index].gameObject;
        if (item.GetComponent<IAttackable>() != null)
        {
            EquipWeapon(item);
        }
        else
        {
            Debug.Log($"{item.name} は装備できません");
        }
    }
}
