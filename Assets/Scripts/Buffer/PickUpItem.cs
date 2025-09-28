using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Transform weaponHoldPoint;
    IAttackable attackable;

   

    public void PickUpWeapon(GameObject weapon)
    {
        // �����GripPoint��T��
        Transform grip = weapon.transform.Find("GripPoint");

        if (grip != null)
        {
            // �e���Z�b�g
            weapon.transform.SetParent(weaponHoldPoint);

            // ���W�Ɖ�]�����킹��
            // GripPoint�����傤��WeaponHoldPoint�ɏd�Ȃ�悤�ɂ���
            weapon.transform.localPosition = -grip.localPosition;
            weapon.transform.localRotation = Quaternion.Inverse(grip.localRotation);
        }
        else
        {
            // GripPoint���Ȃ���΃f�t�H���g�ł҂�����
            weapon.transform.SetParent(weaponHoldPoint);
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
}
