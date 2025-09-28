using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    IAttackable attackable;


    public void PickUpWeaPon(GameObject weapon)
    {
        weapon.transform.SetParent(this.transform);
        attackable = weapon.GetComponent<IAttackable>();
    }
    public void DropWeapon()
    {
        if (attackable != null)
        {
            var weaponObj = (attackable as MonoBehaviour).gameObject;
            weaponObj.transform.SetParent(null);
            attackable = null;
        }
    }

    public void Attack()
    {
        if (attackable != null)
        {
            attackable.Attack();
        }
        else
        {
            Debug.Log("‘fŽè");
        }
    }
}
