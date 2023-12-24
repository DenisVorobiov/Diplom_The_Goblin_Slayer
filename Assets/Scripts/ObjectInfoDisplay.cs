using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInfoDisplay : MonoBehaviour
{
    public TMP_Text infoText;
    public float interactionDistance = 5f;
    public Transform infoPoint;
    private GameObject currentPrefab;

   
    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(infoPoint.position, infoPoint.forward);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractiveObject interactiveObject = hit.transform.GetComponent<InteractiveObject>();
            DisplayObjectInfo(interactiveObject);

            if (Input.GetKeyDown(KeyCode.E))
            {
                KeyInput(interactiveObject);
            }
        }
        else
        {
            infoText.text = "";
            currentPrefab = null;
        }
    }

    private void DisplayObjectInfo(InteractiveObject interactiveObject)
    {
        if (interactiveObject != null)
        {
            infoText.text = interactiveObject.GetObjectInfo();
        }
    }
    public void KeyInput(InteractiveObject interactiveObject)
    {
        if (interactiveObject != null)
        {
            interactiveObject.InteractWithObject();
            currentPrefab = interactiveObject.GetInteractionPrefab();
            Debug.Log("Interacting with object: " + infoText);
        }
    }
}