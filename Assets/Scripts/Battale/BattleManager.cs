using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [SerializeField] private Player _player;
    private Enemy _currentenemy;

    private void Awake()
    {
        instance = this;
    }

    public void StartBattle(Enemy enemyPrefab)
    {
        _currentenemy = Instantiate(enemyPrefab,new Vector3(2,0,0),Quaternion.identity);
        Debug.Log($"ƒoƒgƒ‹ŠJŽn{_player.characterName}{_currentenemy.characterName}");
    }

    public void PlayerAttack()
    {
        if (_currentenemy == null) return;

        _currentenemy.TakeDamage(1);
        

        
    }
    public void EnemyAttack()
    {
        if (_currentenemy == null) return;
        _currentenemy.TakeDamage(0);
    }

    public void CheckBattleState()
    {
        if (_player.hp <= 0)
        {
            Debug.Log($"{_player.characterName}‚Ì”s–k");
        }
        else if(_currentenemy.hp<=0){
            Debug.Log($"{_currentenemy.name}‚ð“|‚µ‚½I");

        }
    }
    public void EndBattle()
    {
        Destroy(_currentenemy.gameObject);
        _currentenemy = null;

        //Invoke(nameof(StartBattle), 2f);
    }

}
