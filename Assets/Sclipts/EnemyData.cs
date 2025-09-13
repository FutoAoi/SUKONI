using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Game/Enemy")]
public class EnemyData : ScriptableObject
{
    [SerializeField] string _enemyName;
    [SerializeField] float _maxHp;
}