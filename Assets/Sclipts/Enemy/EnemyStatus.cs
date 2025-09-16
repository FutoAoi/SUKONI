using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField] EnemyData _enemy;
    float _hp;
    void Start()
    {
        _hp = _enemy.MaxHp;
    }

    public void Damage(float damage)
    {
        _hp -= damage;
        if(_hp < 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(this.gameObject);
    }
}
