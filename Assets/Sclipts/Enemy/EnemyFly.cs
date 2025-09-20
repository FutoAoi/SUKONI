using UnityEngine;

public class EnemyFly : EnemyBase
{
    [Header("ˆÚ“®ŠÖŒW")]
    [SerializeField] float _bootDistance = 30f;
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _flyDistance = 20f;    

    bool _inBoot;
    Vector3 _direction;

    protected override void Update()
    {
        if (_player == null) return;

        _direction = transform.position - _player.transform.position;

        if (!_inBoot)
        {
            CheckBoot();
        }
        else
        {
            Fly();
            base.Update();
        }
    }

    void CheckBoot()
    {
        if (_direction.magnitude <= _bootDistance)
        {
            _inBoot = true;
        }
    }

    void Fly()
    {
        Vector3 targetPos = _player.transform.position + _direction.normalized * _flyDistance;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * _moveSpeed);

        Quaternion targetRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
    }

    protected override void Attack()
    {
        Debug.Log("”ò‚Ô“G‚ªUŒ‚I UŒ‚—ÍF" + _enemy.AttackPower);
    }
}
