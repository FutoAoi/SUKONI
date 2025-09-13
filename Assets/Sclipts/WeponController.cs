using System.Collections;
using UnityEngine;

public class WeponController : MonoBehaviour
{
    [SerializeField] float _shootRate;
    [SerializeField] float _maxBullets;
    [SerializeField] float _reloadTime;
    [SerializeField] Transform _shootPos;
    [SerializeField] GameObject _bullets;
    [SerializeField] PlayerFPS _fps;

    bool _canNotShoot = false;
    bool _isReloading = false;
    bool _isADS = false;
    float _remainBullets;
    [SerializeField] Animator _an;

    public float MaxBullets => _maxBullets;
    public float RemainBullets => _remainBullets;
    void Start()
    {
        _remainBullets = _maxBullets;
    }

    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            _isADS = true;
        }
        else
        {
            _isADS = false;
        }

        _an.SetBool("IsADS", _isADS);

        if(Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        if(Input.GetMouseButton(0) && !_canNotShoot && _remainBullets > 0 && !_isReloading)
        {
            Shoot();
            StartCoroutine(WaitSpan());
        }
    }

    void Shoot()
    {
        _remainBullets--;
        Instantiate(_bullets, _shootPos.position, _shootPos.rotation);
        _fps.Recoil(1f);
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadTime);
        _remainBullets = _maxBullets;
        _isReloading = false;
    }

    IEnumerator WaitSpan()
    {
        _canNotShoot = true;
        yield return new WaitForSeconds(_shootRate);
        _canNotShoot = false;
    }
}
