using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    [SerializeField] private EquipSlotView[] equipViews;

    private void Start()
    {
        var slots = Context.Instance.EquipmentSystem.Slots;

        foreach (var slot in slots)
        {
            var view = equipViews.First(v => v.SlotType == slot.SlotType);
            view.Set(slot);
        }
    }
}
