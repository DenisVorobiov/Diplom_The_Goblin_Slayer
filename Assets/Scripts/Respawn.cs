using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void RespawnEnemy(GameObject enemyObject, float delay)
    {
        StartCoroutine(RespawnAfterDelay(enemyObject, delay));
    }

    private IEnumerator RespawnAfterDelay(GameObject enemyObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyObject.SetActive(true);
    }
}
