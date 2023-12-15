using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



public class InventoryView : MonoBehaviour
{
    [SerializeField] private SlotsObserver _slotsObserver;
    [SerializeField] private Transform _onDragRoot;
    [SerializeField] private InventorySlotView[] slots;

    public void Start()
    {
        var slotsData = Context.Instance.InventorySystem.Slots;
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i].SetData(
                slotsData[i],
                _onDragRoot,
                _slotsObserver);
        }
    }

    
}