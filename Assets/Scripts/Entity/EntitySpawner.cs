using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviour
{
    //[SerializeField] private EntityInitializer enemyPrefab;

    [SerializeField] public List<Transform> SpawnPoints;

    [SerializeField] private float patrolRadius = 3.0f;

    [SerializeField] private int numberOfPatrolPoints = 5;

    [SerializeField] private ObjectPool<EntityInitializer> _enemyPool;

    private void Start()
    {
        //_enemyPool = new ObjectPool<EntityInitializer>(entity.Prefab, 3);

        var spawnData = Context.Instance.DataSystem.SpawnData;
        foreach (var sd in spawnData)
        {
            StartCoroutine(SpawnEnemy(sd));
        }
       
    }

    private IEnumerator SpawnEnemy(SpawnData spawnData)
    {
        var entities = Context.Instance.DataSystem.EntityData;
        var entity = entities.FirstOrDefault(e => e.Name == spawnData.name);
        for (int i = 0; i < spawnData.count; ++i)
        {
            Transform randomSpawnPoint = SpawnPoints[Random.Range(0, SpawnPoints.Count)];
            Vector3 spawnPosition = randomSpawnPoint.position;
            Quaternion spawnRotation = randomSpawnPoint.rotation;

           
            List<Vector3> patrolPoints = new List<Vector3>();
            for (int j = 0; j < numberOfPatrolPoints; j++)
            {
                Vector3 patrolPoint = spawnPosition + new Vector3(Random.Range(-patrolRadius, patrolRadius), 0, Random.Range(-patrolRadius, patrolRadius));
                patrolPoints.Add(patrolPoint);
            }

            GameObject enemy = Instantiate(entity.Prefab, spawnPosition, spawnRotation);
            
            //EntityInitializer enemy = _enemyPool.GetObject();
            //enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            BaseAIController patrolComponent = enemy.GetComponent<BaseAIController>();
            if (patrolComponent != null)
            {
                patrolComponent.patrolPoints = patrolPoints;
            }

            yield return new WaitForSeconds(spawnData.delay);
        }
    }

}