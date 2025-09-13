using UnityEngine;
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Item/Weapon")]
public class WeponData : ItemData
{
    [SerializeField] int Damege;
    [SerializeField] float rate;
}
