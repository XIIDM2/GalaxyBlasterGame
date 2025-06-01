using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    Fixed,
    Random
}

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] spawnPoints;

    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private SpawnType spawnType;

    [SerializeField] private int spawnPointNumber;

    [SerializeField] private float spawnTime;

    [SerializeField] private int spawnAmount;

    private void Start()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("spawnPoints are none!");
        }

        StartCoroutine(SpawnEnemiesRoutine());

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnEnemiesRoutine()
    {
        while (true)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                if (spawnType == SpawnType.Fixed)
                {
                    SpawnEnemyAtSpawnPoint(spawnPointNumber);
                }
                else if (spawnType == SpawnType.Random)
                {
                    SpawnEnemyAtRandomSpawnPoint();
                }
            }

            yield return new WaitForSeconds(spawnTime);
            
        }
    }

    private void SpawnEnemyAtSpawnPoint(int spawnPointNumber)
    {
        if (spawnPointNumber < 0 || spawnPointNumber >= spawnPoints.Length)
        {
            Debug.LogError("Wrong SpawnPointNumber");
            spawnPointNumber = Mathf.Clamp(spawnPointNumber, 0, spawnPoints.Length - 1);
        }

        Vector3 spawnPosition = GetRandomPositionInSpawnPoint(spawnPointNumber);

        SpawnEnemy(spawnPosition);
    }

    private void SpawnEnemyAtRandomSpawnPoint()
    {
        int randomSpawnPointNumber = Random.Range(0, spawnPoints.Length);

        Vector3 spawnPosition = GetRandomPositionInSpawnPoint(randomSpawnPointNumber);

        SpawnEnemy(spawnPosition);
    }

    private Vector3 GetRandomPositionInSpawnPoint(int spawnPointNumber)
    {
        if (spawnPointNumber < 0 || spawnPointNumber >= spawnPoints.Length)
        {
            Debug.LogError("Wrong SpawnPointNumber");
            return Vector3.zero;
        }

        Vector3 centralPositionInSpawnPoint = spawnPoints[spawnPointNumber].transform.position;
                
        Vector2 randomCircle = Random.insideUnitCircle * spawnPoints[spawnPointNumber].Radius;

        Vector3 randomPosition = new Vector3(randomCircle.x, randomCircle.y, 0) + centralPositionInSpawnPoint;

        randomPosition.z = 0;

        return randomPosition;
    
    }

    private void SpawnEnemy(Vector3 spawnPosition)
    {
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
        
}
