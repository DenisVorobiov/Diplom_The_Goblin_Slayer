using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public Transform target; // Прицільна точка

    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            targetPosition.y = transform.position.y; // Забезпечує горизонтальний обертання

            // Повертаємо персонажа в напрямку приціла (горизонтально)
            transform.LookAt(targetPosition);
        }
    }
}