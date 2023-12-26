using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y;
            transform.LookAt(targetPosition);
        }
    }
}