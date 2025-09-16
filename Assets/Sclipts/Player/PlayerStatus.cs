using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] float _maxHp;
    float _currentHp;

    private void Start()
    {
        _currentHp = _maxHp;
    }

    public void Damage(float damage)
    {
        _currentHp -= damage;
        if(_currentHp < 0 )
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("si");
    }
}
