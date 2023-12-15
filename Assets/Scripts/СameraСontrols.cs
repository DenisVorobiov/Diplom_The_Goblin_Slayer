using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraControls : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 15;
    [SerializeField] private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void FixedUpdate()
    {
        Vector3 lookDirection = mainCamera.transform.forward;
        lookDirection.y = 0f; 

        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        float yCamera = targetRotation.eulerAngles.y;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCamera, 0), turnSpeed * Time.fixedDeltaTime);
    }
}