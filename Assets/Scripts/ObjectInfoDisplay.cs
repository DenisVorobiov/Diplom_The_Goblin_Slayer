using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInfoDisplay : MonoBehaviour
{
    public TMP_Text infoText;
    public float interactionDistance = 3f;
    public Transform playerCamera;

    private void Update()
    {
        RaycastHit hit;
        Ray ray = playerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Якщо попали в інтерактивний об'єкт
            DisplayObjectInfo(hit.transform.GetComponent<InteractiveObject>());
        }
        else
        {
            // Якщо не попали в інтерактивний об'єкт, приховати текст
            infoText.text = "";
        }
    }

    private void DisplayObjectInfo(InteractiveObject interactiveObject)
    {
        if (interactiveObject != null)
        {
            // Відобразити інформацію об'єкта в текстовому полі
            infoText.text = interactiveObject.objectName;
        }
    }
}