using System;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    [SerializeField] public Transform _root;
    [SerializeField] private ShopItemView _prefab;

    private void Start()
    {
        var shopItems = Context.Instance.DataSystem.ShopItems;
        foreach (var si in shopItems)
        {
            ShopItemView view = Instantiate(_prefab, _root);
            view.SetData(si);
        }
    }
}