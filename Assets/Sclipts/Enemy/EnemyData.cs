using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Game/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string _enemyName;
    [SerializeField] float _maxHp;

    public string EnemyName => _enemyName;
    public float MaxHp => _maxHp;
}