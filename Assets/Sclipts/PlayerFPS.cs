using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    [Header("ÉJÉÅÉâê›íË")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] float _xSensitivity, _ySensitivity;
    [SerializeField] float _maxCameraAngle;

    float _xRot, _yRot;
    float _clampYRot;
    Quaternion _playerRot;
    private void Start()
    {
        _playerRot = transform.localRotation;
    }
    void Update()
    {
        FPSCameraMove(); 
    }

    private void FPSCameraMove()
    {
        _xRot = Input.GetAxis("Mouse X") * _xSensitivity;
        _yRot = Input.GetAxis("Mouse Y") * _ySensitivity;

        _clampYRot -=_yRot;
        _clampYRot = Mathf.Clamp( _clampYRot, -_maxCameraAngle, _maxCameraAngle);

        _playerRot *= Quaternion.Euler(0f, _xRot, 0f);

        _mainCamera.transform.localRotation = Quaternion.Euler(_clampYRot, 0f, 0f);
        transform.localRotation = _playerRot;
    }
}
