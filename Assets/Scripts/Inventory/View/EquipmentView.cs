using System;
using UnityEngine;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private SlotsObserver _slotsObserver;
    //[SerializeField] private InventorySlotView weaponSlotView;
    //[SerializeField] private InventorySlotView chestSlotView;
    //[SerializeField] private InventorySlotView bootsSlotView;
    [SerializeField] private InventorySlotView[] slots;
    [SerializeField] private Transform _onDragRoot;

    

    private void Start()
    {
        //var equipmentSystem = Context.Instance.EquipmentSystem;

        //weaponSlotView.SetData(equipmentSystem.WeaponSlot, _onDragRoot, _slotsObserver);
        //chestSlotView.SetData(equipmentSystem.ChestSlot, _onDragRoot, _slotsObserver);
        //bootsSlotView.SetData(equipmentSystem.BootsSlot, _onDragRoot, _slotsObserver);

        var slotsData = Context.Instance.EquipmentSystem.Slots;
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i].SetData(
                slotsData[i],
                _onDragRoot,
                _slotsObserver);

        }
    }
}

    