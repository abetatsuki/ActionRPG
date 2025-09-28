using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Transform weaponHoldPoint;
    [SerializeField] private Inventory inventory;

    private IAttackable attackable;
    private GameObject currentWeapon;

    /// <summary>
    /// ���C�L���X�g�Ȃǂ���E�����Ƃ��ɌĂ�
    /// </summary>
    public void PickUp(GameObject itemObj)
    {
        var itemBase = itemObj.GetComponent<ItemBase>();
        if (itemBase == null)
        {
            Debug.Log($"{itemObj.name} �͏E���܂���");
            return;
        }

        // �C���x���g���ɒǉ�
        inventory.AddItem(itemBase);

        // ����Ȃ玩���ő���
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
    /// ����𑕔�����
    /// </summary>
    public void EquipWeapon(GameObject weapon)
    {
        // �O�̕�����C���x���g���ɖ߂�
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false); // ���[���h��ɂ͕\�����Ȃ�
        }

        currentWeapon = weapon;
        currentWeapon.SetActive(true); // �������͕\��

        // GripPoint �ɍ��킹�Ĉʒu�E��]�𒲐�
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
            Debug.Log("�f��");
        }
    }

    /// <summary>
    /// �C���x���g�����瑕����؂�ւ���
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
            Debug.Log($"{item.name} �͑����ł��܂���");
        }
    }
}
