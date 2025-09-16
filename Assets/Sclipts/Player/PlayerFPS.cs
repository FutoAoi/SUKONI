using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    [Header("ÉJÉÅÉâê›íË")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] float _xSensitivity, _ySensitivity;
    [SerializeField] float _maxCameraAngle;

    [Header("ÉäÉRÉCÉãê›íË")]
    [SerializeField] float _recoilRecoverySpeed;

    float _xRot, _yRot;
    float _finalX, _finalY;
    float _clampYRot;
    Quaternion _playerRot;

    Vector2 _currentRecoil;
    Vector2 _targetRecoil;
    private void Start()
    {
        _playerRot = transform.localRotation;
    }
    void Update()
    {
        FPSCameraMove();
        ApplyRecoil();
    }

    private void FPSCameraMove()
    {
        _xRot = Input.GetAxis("Mouse X") * _xSensitivity;
        _yRot = Input.GetAxis("Mouse Y") * _ySensitivity;

        _clampYRot -=_yRot;
        _clampYRot = Mathf.Clamp( _clampYRot, -_maxCameraAngle, _maxCameraAngle);

        _playerRot *= Quaternion.Euler(0f, _xRot, 0f);

        _finalX = _clampYRot + _currentRecoil.y;
        _finalY = _currentRecoil.x;

        _mainCamera.transform.localRotation = Quaternion.Euler(_finalX, _finalY, 0f);
        transform.localRotation = _playerRot;
    }
    void ApplyRecoil()
    {
        _currentRecoil = Vector2.Lerp(_currentRecoil, _targetRecoil, Time.deltaTime * _recoilRecoverySpeed);
        _targetRecoil = Vector2.Lerp(_targetRecoil, Vector2.zero, Time.deltaTime * _recoilRecoverySpeed);
    }

    public void Recoil(float Xrecoil, float Yrecoil)
    {
        float x = Random.Range(-Xrecoil, Xrecoil);
        float y = Random.Range(0, Yrecoil);

        _targetRecoil += new Vector2(x, -y);
    }
}
