using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public string objectName = "Default Object";
    public float interactionDistance = 3f;
    public Transform playerCamera;
    public GameObject interactionPrefab;
    private Transform lastObject;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            
            if (hit.transform != lastObject)
            {
                lastObject = hit.transform;
                
                DisplayObjectName(objectName);
            }

         
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                InteractWithObject();
            }
        }
        else
        {
            
            if (lastObject != null)
            {
                HideObjectName();
                lastObject = null;
            }
        }
    }

    private void DisplayObjectName(string name)
    {
       
        Debug.Log("Displaying object name: " + name);
    }

    private void HideObjectName()
    {
      
        Debug.Log("Hiding object name");
    }

    private void InteractWithObject()
    {
        
        Debug.Log("Interacting with object: " + objectName);
        
        if (interactionPrefab != null)
        {
            
            bool isActive = interactionPrefab.activeSelf;

           
            interactionPrefab.SetActive(!isActive);
        }
        
    }
}