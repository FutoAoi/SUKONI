using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Šî‘bİ’è")]
    [SerializeField] protected EnemyData _enemy;

    protected float _hp;
    protected float _attackTimer;
    protected GameObject _player;

    protected virtual void Start()
    {
        _hp = _enemy.MaxHp;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected virtual void Update()
    {
        if (_player == null) return;
        _attackTimer += Time.deltaTime;
        if(_attackTimer > _enemy.AttackSpan)
        {
            Attack();
            _attackTimer = 0;
        }
    }

    /// <summary>
    /// ƒ_ƒ[ƒW‚ğó‚¯‚éˆ—
    /// </summary>
    public virtual void Damage(float damage)
    {
        _hp -= damage;
        if (_hp <= 0) Die(); 
    }

    /// <summary>
    /// €–Sˆ—
    /// </summary>
    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }

    /// <summary>
    /// UŒ‚ˆ—
    /// </summary>
    protected abstract void Attack();
}
