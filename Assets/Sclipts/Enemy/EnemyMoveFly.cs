using System.Linq;
using UnityEngine;

public class EnemyMoveFly : MonoBehaviour
{
    [SerializeField] float _bootDistance;
    [SerializeField] float _attackPower;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _flyDistance;

    GameObject _player;
    Vector3 _direction;
    bool _inBoot;

    Vector3 targetPoint;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _direction = transform.position - _player.transform.position;
        if (!_inBoot)
        {
            CheckBoot();
        }
        else
        {
            Fly();
        }
    }

    void CheckBoot()
    {
        if(_direction.magnitude <= _bootDistance)
        {
            _inBoot = true;
        }
    }
    void Fly()
    {
        Vector3 targetPos = _player.transform.position + _direction.normalized * _flyDistance;
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * 1f);
        Quaternion targetRotation = Quaternion.LookRotation(_player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1f);
    }
}
