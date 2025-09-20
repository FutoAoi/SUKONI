using UnityEngine;
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Item/Weapon")]
public class WeponData : ItemData
{
    [SerializeField] int _damege;
    [SerializeField] float _shootRate;
    [SerializeField] float _maxBullets;
    [SerializeField] float _reloadTime;
    [SerializeField] float _xrecoil, _yrecoil;
    [SerializeField] float _range;

    public int Damage => _damege;
    public float ShootRate => _shootRate;
    public float MaxBullets => _maxBullets;
    public float ReloadTime => _reloadTime;
    public float Xrecoil => _xrecoil;
    public float Yrecoil => _yrecoil;
    public float Range => _range;
}
