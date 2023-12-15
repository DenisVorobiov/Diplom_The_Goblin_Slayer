using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private string _fireSfxKey;
    public PlayerMovementNew arrowPrefab; 
    public Transform arrowSpawnPoint;
    public float arrowSpeed;
    private ObjectPool<PlayerMovementNew> _bulletsPool;

    private void Start()
    {
        _bulletsPool = new ObjectPool<PlayerMovementNew>(arrowPrefab, null, 5);
        
    }

    public void Fire()
    {
        PlayerMovementNew bullet = _bulletsPool.GetObject();

        bullet.transform.SetPositionAndRotation(arrowSpawnPoint.position, arrowSpawnPoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
         rb.velocity = arrowSpawnPoint.forward * arrowSpeed;

        //Context.Instance.AudioSystem.PlaySFX(new SoundSettings(_fireSfxKey,transform.position));
    }
    
}


