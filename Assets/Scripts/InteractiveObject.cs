using System;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string objectName = "Default Object";
    [SerializeField] private GameObject interactionPrefab;
    

    public void InteractWithObject()
    {
        if (interactionPrefab != null)
        {
            bool isActive = interactionPrefab.activeSelf;
            interactionPrefab.SetActive(!isActive);
        }
        
    }
    public GameObject GetInteractionPrefab()
    {
        return interactionPrefab;
    }
    public string GetObjectInfo()
    {
        
        return objectName;
    }
}