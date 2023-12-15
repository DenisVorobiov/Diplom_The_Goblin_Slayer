using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EntityInitializer enemyPrefab;

    [SerializeField] public int count = 6;

    [SerializeField] public List<Transform> SpawnPoints;

    [SerializeField] private float patrolRadius = 3.0f;

    [SerializeField] private int numberOfPatrolPoints = 5;

    [SerializeField] private float time;

    [SerializeField] private ObjectPool<EntityInitializer> _enemyPool;

    private int countSpawnPoint;


    private void Start()
    {
         _enemyPool = new ObjectPool<EntityInitializer>(enemyPrefab,null, count);

        StartCoroutine(SpawnEnemy());
    }
    


    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < count; i++)
        {
            if (countSpawnPoint >= SpawnPoints.Count)
            {
                countSpawnPoint = 0;
            }
            Transform SpawnPoint = SpawnPoints[countSpawnPoint];//Random.Range(0, SpawnPoints.Count)
            Vector3 spawnPosition = SpawnPoint.position;
            Quaternion spawnRotation = SpawnPoint.rotation;

            EntityInitializer enemy = _enemyPool.GetObject();
            enemy.transform.position = spawnPosition;
            enemy.transform.rotation = spawnRotation;

            // EntityInitializer enemy = Instantiate(enemyPrefab, spawnPosition, spawnRotation);

            List<Vector3> patrolPoints = new List<Vector3>();
            for (int j = 0; j < numberOfPatrolPoints; j++)
            {
                Vector3 patrolPoint = spawnPosition + new Vector3(Random.Range(-patrolRadius, patrolRadius), 0, Random.Range(-patrolRadius, patrolRadius));
                patrolPoints.Add(patrolPoint);
            }

            BaseAIController patrolComponent = enemy.GetComponent<BaseAIController>();
            if (patrolComponent != null)
            {
                patrolComponent.patrolPoints = patrolPoints;
            }

            countSpawnPoint++;

            yield return new WaitForSeconds(time);
        }
      
        
    }


}