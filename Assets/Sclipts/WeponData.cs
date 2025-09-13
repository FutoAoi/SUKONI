using UnityEngine;
[CreateAssetMenu(fileName = "NewWeapon", menuName = "Game/Weapon")]
public class WeponData : ItemData
{
    [SerializeField] int Damege;
    [SerializeField] float rate;
}
