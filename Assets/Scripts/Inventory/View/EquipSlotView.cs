using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EquipSlotView : MonoBehaviour
{
    [SerializeField] private Transform _root;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private MeleWaponTriger _triger;
    [SerializeField] private PlayerInput _input;
    public  ItemType SlotType => _itemType;
    private InventorySlot _slot;
    private GameObject _container;

    public void Set (InventorySlot slot)
    {
        _slot = slot;
        slot.OnSlotChanged += DisplayItem;
        slot.OnSlotChanged += Weapon;
        slot.OnSlotChanged += Dagger;
        slot.OnSlotChanged += Shild;
    }

    public void DisplayItem()
    {
        //Destroy
        if (_container != null)
        {
            Destroy(_container);
        }
        //Spawn
        if (!_slot.IsEmpty)
        {
            _container = Instantiate(_slot.Item.ItemData.ItemPrefab, _root);
          
        }
    }
    public void Weapon()
    {
        if (!_slot.IsEmpty&&_slot.SlotType == ItemType.Weapon)
        {
            if (_slot.SlotType == ItemType.Weapon)
            {
                _triger.UpdateWeaponColliderReference();
                _input.isWeaponSlotEmpty = false;
            }
        }
        else if (_slot.IsEmpty&&_slot.SlotType == ItemType.Weapon)
        {
            _input.isWeaponSlotEmpty = true;
        }
    }
    public void Dagger()
    {
        if (!_slot.IsEmpty)
        {
            if (_slot.SlotType == ItemType.Boots)
            {
                _input.isDaggerSlotEmpty = false;
            }
        }
        else 
        {
            _input.isDaggerSlotEmpty = true;
        }
    }
    public void Shild()
    {
        if (!_slot.IsEmpty&&_slot.SlotType == ItemType.Chest)
        {
            if (_slot.SlotType == ItemType.Chest)
            {
                _input.isShieldSlotEmpty = false;
            }
        }
        else if (_slot.IsEmpty&&_slot.SlotType == ItemType.Chest)
        {
            _input.isShieldSlotEmpty = true;
        }
    }

    public void OnDestroy()
    {
        _slot.OnSlotChanged -= DisplayItem;
        _slot.OnSlotChanged -= Weapon;
        _slot.OnSlotChanged += Dagger;
        _slot.OnSlotChanged += Shild;
    }
}
