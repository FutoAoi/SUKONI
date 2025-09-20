using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Game/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string _enemyName;
    [SerializeField] float _maxHp;
    [SerializeField] float _attackPower;
    [SerializeField] float _attackSpan;

    public string EnemyName => _enemyName;
    public float MaxHp => _maxHp;
    public float AttackPower => _attackPower;
    public float AttackSpan => _attackSpan;
}