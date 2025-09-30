using UnityEngine;

public class StatusBase : MonoBehaviour
{
    public string characterName;
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
        Debug.Log($"{characterName}‚Í“|‚ê‚½");
    }

}
