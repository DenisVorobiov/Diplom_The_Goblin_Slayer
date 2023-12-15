using TMPro;
using UnityEngine;

public class ItemDeletionWindow : MonoBehaviour
{
    public static ItemDeletionWindow Instance;
    [SerializeField] private TextMeshProUGUI itemNameText;

    private InventorySlot _currentSlot;

    private void Awake()
    {
        gameObject.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Show(InventorySlot slot)
    {
        _currentSlot = slot;

        itemNameText.text = $"Delete {_currentSlot.Item.ItemData.Name}?";

        
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            GetComponentInParent<Canvas>().transform as RectTransform,
            Input.mousePosition,
            GetComponentInParent<Canvas>().worldCamera,
            out Vector2 localPoint);

        transform.localPosition = localPoint;

        gameObject.SetActive(true);
    }

    public void ConfirmDeletion()
    {
        Debug.Log("ConfirmDeletion");
        _currentSlot.Clear();
        gameObject.SetActive(false);
    }

    public void CancelDeletion()
    {
        Debug.Log("CancelDeletion");
        gameObject.SetActive(false);
    }
}