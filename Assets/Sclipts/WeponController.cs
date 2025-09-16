using System.Collections;
using System.Drawing;
using UnityEngine;

public class WeponController : MonoBehaviour
{
    [SerializeField] float _shootRate;
    [SerializeField] float _maxBullets;
    [SerializeField] float _reloadTime;
    [SerializeField] float _xrecoil, _yrecoil;
    [SerializeField] Transform _shootPos;
    [SerializeField] GameObject _bullets;
    [SerializeField] PlayerFPS _fps;
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] Camera _mainCamera;
    float _range = 100f;
    float _damage = 10f;
    [SerializeField] LineRenderer _lineRendererPrefab;

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
        //Instantiate(_bullets, _shootPos.position, _shootPos.rotation);
        RaycastHit hit;
        Vector3 hitpoint;
        if(Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _range))
        {
            hitpoint = hit.point;

            EnemyStatus _target = hit.transform.GetComponent<EnemyStatus>();
            if(_target != null)
            {
                _target.Damage(_damage);
                DamagePopup.Create(hitpoint, _damage);
            }
        }
        else
        {
            hitpoint = _mainCamera.transform.position + _mainCamera.transform.forward * _range;
        }
        StartCoroutine(ShowBulletLine(hitpoint));
        _fps.Recoil(_xrecoil, _yrecoil);
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

    System.Collections.IEnumerator ShowBulletLine(Vector3 hitpoint)
    {
        LineRenderer _line = Instantiate(_lineRendererPrefab);

        _line.SetPosition(0, _muzzlePoint.position);
        _line.SetPosition(1, hitpoint);

        yield return new WaitForSeconds(0.05f);

        Destroy(_line.gameObject);
    }
}
