using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _count;
    [SerializeField] private TextMeshProUGUI _name;
    private Transform _onDragRoot;
    private Transform _defaultParent;
    private Action<InventorySlot> _onEndDrag;
    public Action Injecting;
    private InventorySlot _data;
    private ISlotsObserver _slotsObserver;
   

    private void Start()
    {
        _defaultParent = transform.parent;
    }

    public void DisplayItem(InventorySlot data, Transform onDragRoot, Action<InventorySlot> onEndDrag)
    {
        _data = data;
        _onDragRoot = onDragRoot;
        _onEndDrag = onEndDrag;
        _icon.gameObject.SetActive(!data.IsEmpty);
        _count.gameObject.SetActive(!data.IsEmpty);
       
        if (!data.IsEmpty)
        {
            _icon.sprite = data.Item.ItemData.Icon;
            _count.text = data.Item.Count.ToString();
           
        }
    }

    public void DisplayItem(InventorySlot data, Transform onDragRoot, ISlotsObserver slotsObserver)
    {
        _data = data;
        _onDragRoot = onDragRoot;

        _slotsObserver = slotsObserver;

        _icon.gameObject.SetActive(!data.IsEmpty);
        _count.gameObject.SetActive(!data.IsEmpty);
       
        if (!data.IsEmpty)
        {
            _icon.sprite = data.Item.ItemData.Icon;
            _count.text = data.Item.Count.ToString();
            
        }
    }
   
    private void InsertInGrid()
    {
        _canvasGroup.blocksRaycasts = true;
        _onEndDrag?.Invoke(_data);
        _slotsObserver?.SetOnEndDragSlot(_data);
        transform.SetParent(_defaultParent);
        ((RectTransform)transform).anchoredPosition = Vector2.zero;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        transform.SetParent(_onDragRoot);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
            InsertInGrid();
    }

}