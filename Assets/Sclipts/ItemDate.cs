using UnityEngine;

public class ItemData : ScriptableObject
{
    [SerializeField] string _itemName;
    [SerializeField] Sprite _icon;

    public string Name => _itemName;
    public Sprite Icon => _icon;
}