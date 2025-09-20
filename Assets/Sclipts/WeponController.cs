using System.Collections;
using UnityEngine;

public class WeponController : MonoBehaviour
{
    [Header("•Šíƒf[ƒ^")]
    [SerializeField] WeponData _wepon;
    [Header("‚»‚Ì‘¼")]
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] PlayerFPS _fps;
    [SerializeField] Camera _mainCamera;
    [SerializeField] LineRenderer _lineRendererPrefab;
    [SerializeField] Animator _an;

    float _remainBullets;

    bool _canNotShoot = false;
    bool _isReloading = false;
    bool _isADS = false;

    public float MaxBullets => _wepon.MaxBullets;
    public float RemainBullets => _remainBullets;
    void Start()
    {
        _remainBullets = _wepon.MaxBullets;
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
        RaycastHit hit;
        Vector3 hitpoint;
        if(Physics.Raycast(_mainCamera.transform.position, _mainCamera.transform.forward, out hit, _wepon.Range))
        {
            hitpoint = hit.point;

            EnemyBase _target = hit.transform.GetComponent<EnemyBase>();
            if(_target != null)
            {
                _target.Damage(_wepon.Damage);
                DamagePopup.Create(hitpoint, _wepon.Damage);
            }
        }
        else
        {
            hitpoint = _mainCamera.transform.position + _mainCamera.transform.forward * _wepon.Range;
        }
        StartCoroutine(ShowBulletLine(hitpoint));
        _fps.Recoil(_wepon.Xrecoil, _wepon.Yrecoil);
    }

    IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_wepon.ReloadTime);
        _remainBullets = _wepon.MaxBullets;
        _isReloading = false;
    }

    IEnumerator WaitSpan()
    {
        _canNotShoot = true;
        yield return new WaitForSeconds(_wepon.ShootRate);
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
