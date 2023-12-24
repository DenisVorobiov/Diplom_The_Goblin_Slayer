using System;
using UnityEngine;

public class EquipmentView : MonoBehaviour
{
    [SerializeField] private SlotsObserver _slotsObserver;
    [SerializeField] private InventorySlotView[] slots;
    [SerializeField] private Transform _onDragRoot;

    

    private void Start()
    {
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

    