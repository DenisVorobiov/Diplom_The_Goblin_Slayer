using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewSpawner : MonoBehaviour
{
    [SerializeField] private List<EntityInitializer> enemyPrefabs;
    [SerializeField] private List<EntityInitializer> prefabNPC;
    [SerializeField] public int count = 6;
    [SerializeField] public int countNPC = 6;
    [SerializeField] public List<Transform> SpawnPoints;
    [SerializeField] public List<Transform> SpawnPointsNPC;
    [SerializeField] private float patrolRadius = 3.0f;
    [SerializeField] private int numberOfPatrolPoints = 5;
    [SerializeField] private float time;
    private int countSpawnPoint;
    private int countSpawnPointNPC;
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnNPC());
    }

    private IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < count; i++)
        {
            if (countSpawnPoint >= SpawnPoints.Count)
            {
                countSpawnPoint = 0;
            }

            Transform spawnPoint = SpawnPoints[countSpawnPoint];
            Vector3 spawnPosition = spawnPoint.position;
            Quaternion spawnRotation = spawnPoint.rotation;

            int randomIndex = Random.Range(0, enemyPrefabs.Count);

            EntityInitializer randomPrefab = enemyPrefabs[randomIndex];

            EntityInitializer enemy = Instantiate(randomPrefab, spawnPosition, spawnRotation);

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
    private IEnumerator SpawnNPC()
    {
        for (int i = 0; i < countNPC; i++)
        {
            if (countSpawnPointNPC >= SpawnPointsNPC.Count)
            {
                countSpawnPointNPC = 0;
            }

            Transform spawnPointNPC = SpawnPointsNPC[countSpawnPointNPC];
            Vector3 spawnPositionNPC = spawnPointNPC.position;
            Quaternion spawnRotationNPC = spawnPointNPC.rotation;

            int randomIndexNPC = Random.Range(0, prefabNPC.Count);

            EntityInitializer randomPrefabNPC = prefabNPC[randomIndexNPC];

            Instantiate(randomPrefabNPC, spawnPositionNPC, spawnRotationNPC);

            countSpawnPointNPC++;

            yield return new WaitForSeconds(time);
        }
    }
}