
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;
    //[SerializeField] private GameObject _shop;
    public void OnPlayClick()
    {
        Context.Instance.AppSystem.Trigger(AppTrigger.ToGameplay);
        // SceneManager.LoadScene(1);
    }

    public void OnOptionsClick()
    {
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMenuOptionsScreen);
       // SceneManager.LoadScene(2);
    }
    public void OnBackClick()
    {
        Context.Instance.AppSystem.Trigger(AppTrigger.ToMainMenu);
       // SceneManager.LoadScene(0);
    }

    public void OnInventoryClick()
    {
        _inventory.SetActive(!_inventory.activeSelf);
    }
//
    //public void OnShopClick()
    //{
    //    _shop.SetActive(!_inventory.activeSelf);
    //}

    public void OnExitClick()
    {
       // Debug.Log("Exit");
       Application.Quit();
    }

}
