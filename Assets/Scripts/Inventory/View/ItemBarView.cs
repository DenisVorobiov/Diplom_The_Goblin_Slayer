using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBarView : MonoBehaviour
{

    [SerializeField] private SlotsObserver _slotsObserver;
    [SerializeField] private InventorySlotView[] slots;
    [SerializeField] private Transform _onDragRoot;



    private void Start()
    {
      
        var slotsData = Context.Instance.ItemBarSystem.Slots;
        for (int i = 0; i < slots.Length; ++i)
        {
            slots[i].SetData(
                slotsData[i],
                _onDragRoot,
                _slotsObserver);

        }
    }
}
