using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlotView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private InventoryItemView _itemView;
    private InventorySlot _data;
    private Transform _onDragRoot;
    private Action _onEnter;
    private Action _onExit;
    private Action<InventorySlot> _onEndDrag;
    private ISlotsObserver _slotsObserver;

    public void SetData(InventorySlot data, Transform onDragRoot, Action onEnter, Action onExit,
        Action<InventorySlot> onEndDrag)
    {
        _data = data;
        _onDragRoot = onDragRoot;
        _data.OnSlotChanged += DisplaySlot;

        _onEnter = onEnter;
        _onExit = onExit;
        _onEndDrag = onEndDrag;

        DisplaySlot();
    }

    public void SetData(InventorySlot data, Transform onDragRoot, ISlotsObserver slotsObserver)
    {
        _data = data;
        _onDragRoot = onDragRoot;
        _data.OnSlotChanged += DisplaySlot;
        _slotsObserver = slotsObserver;

        DisplaySlot();
    }

    private void OnDestroy()
    {
        _data.OnSlotChanged -= DisplaySlot;
    }

    private void DisplaySlot()
    {
        _itemView.DisplayItem(_data, _onDragRoot, _slotsObserver);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _slotsObserver?.SetHoveredSlot(_data);
        _onEnter?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _slotsObserver?.SetHoveredSlot(null);
        _onExit?.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ItemDeletionWindow.Instance != null)

            ItemDeletionWindow.Instance.Show(_data);
        
    }
}