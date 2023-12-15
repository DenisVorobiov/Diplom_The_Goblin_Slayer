using UnityEngine;


public interface ISlotsObserver
{
    void SetHoveredSlot(InventorySlot slot);
    void SetOnEndDragSlot(InventorySlot slot);
}

public class SlotsObserver : MonoBehaviour, ISlotsObserver
{
    private InventorySlot _currentSlot;

    public void SetHoveredSlot(InventorySlot slot)
    {
        _currentSlot = slot;
    }

    public void SetOnEndDragSlot(InventorySlot slot)
    {
        if (_currentSlot != null)
            InventorySlot.SwapItems(_currentSlot, slot);
    }
}