using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<EntityInitializer> enemyPrefabs;
    [SerializeField] public int count = 6;
    [SerializeField] public List<Transform> SpawnPoints;
    [SerializeField] private float patrolRadius = 3.0f;
    [SerializeField] private int numberOfPatrolPoints = 5;
    [SerializeField] private float time;

    private Dictionary<EntityInitializer, ObjectPool<EntityInitializer>> _enemyPools;
    private int countSpawnPoint;

    private void Start()
    {
        // Ініціалізуємо словник для зберігання окремих пулів для кожного префабу
        _enemyPools = new Dictionary<EntityInitializer, ObjectPool<EntityInitializer>>();

        // Заповнюємо словник пулами
        foreach (var prefab in enemyPrefabs)
        {
            _enemyPools[prefab] = new ObjectPool<EntityInitializer>(prefab, null, count);
        }

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

            Transform spawnPoint = SpawnPoints[countSpawnPoint];
            Vector3 spawnPosition = spawnPoint.position;
            Quaternion spawnRotation = spawnPoint.rotation;

            // Визначаємо індекс унікального префабу
            int randomIndex = Random.Range(0, enemyPrefabs.Count);

            // Вибираємо префаб за індексом
            EntityInitializer randomPrefab = enemyPrefabs[randomIndex];

            // Беремо пул для вибраного префабу зі словника
            ObjectPool<EntityInitializer> pool = _enemyPools[randomPrefab];

            // Отримуємо об'єкт з пулу
            EntityInitializer enemy = pool.GetObject();
            enemy.transform.position = spawnPosition;
            enemy.transform.rotation = spawnRotation;

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