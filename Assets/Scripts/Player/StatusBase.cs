using UnityEngine;

public class StatusBase : MonoBehaviour
{
    public string name;
    public int hp;
    public int Maxhp;
    public int power;


    public void  TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0) Die();
    }

    public void TakeHeal(int heal)
    {
        if (Maxhp <= hp + heal)
        {
            hp = Maxhp;
        }
        else if (Maxhp >= hp + heal)
        {
            hp = heal;
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{name}‚Í“|‚ê‚½");
    }

}
