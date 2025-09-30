using UnityEngine;

public class Enemy : StatusBase
{

    protected override void Die()
    {
        Debug.Log($"{characterName}‚ð“|‚µ‚½");
    }
}
