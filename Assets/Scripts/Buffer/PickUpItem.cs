using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] private Transform weaponHoldPoint;
    IAttackable attackable;

   

    public void PickUpWeapon(GameObject weapon)
    {
        // 武器のGripPointを探す
        Transform grip = weapon.transform.Find("GripPoint");

        if (grip != null)
        {
            // 親をセット
            weapon.transform.SetParent(weaponHoldPoint);

            // 座標と回転を合わせる
            // GripPointがちょうどWeaponHoldPointに重なるようにする
            weapon.transform.localPosition = -grip.localPosition;
            weapon.transform.localRotation = Quaternion.Inverse(grip.localRotation);
        }
        else
        {
            // GripPointがなければデフォルトでぴったり
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
            Debug.Log("素手");
        }
    }
}
