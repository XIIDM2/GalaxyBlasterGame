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
    [SerializeField] private GameObject entityPrefab;

    [SerializeField] private SpawnPoint[] spawnPoints;

    [SerializeField] private SpawnType spawnType;

    [SerializeField] private int spawnAmount;

    [SerializeField] private int spawnPointNumber;

    [SerializeField] private bool loopSpawn;

    [SerializeField] private float spawnTime;



    private void Start()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("spawnPoints are none!");
        }


        if (!loopSpawn)
        {
            SpawnEntities();
        }
        else 
        {
            StartCoroutine(SpawnEntitiesRoutine());
        }


    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private void SpawnEntities()
    {
        if (spawnType == SpawnType.Fixed)
        {
            SpawnEntityAtPoint(spawnPointNumber);
        }
        else if (spawnType == SpawnType.Random)
        {
            SpawnEntityAtRandomSpawnPoint();
        }
    }

    private IEnumerator SpawnEntitiesRoutine()
    {
        while (loopSpawn)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                if (spawnType == SpawnType.Fixed)
                {
                    SpawnEntityAtPoint(spawnPointNumber);
                }
                else if (spawnType == SpawnType.Random)
                {
                    SpawnEntityAtRandomSpawnPoint();
                }
            }

            yield return new WaitForSeconds(spawnTime);
            
        }
    }

    private void SpawnEntityAtPoint(int spawnPointNumber)
    {
        if (spawnPointNumber < 0 || spawnPointNumber >= spawnPoints.Length)
        {
            Debug.LogError("Wrong SpawnPointNumber");
            spawnPointNumber = Mathf.Clamp(spawnPointNumber, 0, spawnPoints.Length - 1);
        }

        Vector3 spawnPosition = GetRandomPositionInSpawnPoint(spawnPointNumber);

        SpawnEntity(spawnPosition);
    }

    private void SpawnEntityAtRandomSpawnPoint()
    {
        int randomSpawnPointNumber = Random.Range(0, spawnPoints.Length);

        Vector3 spawnPosition = GetRandomPositionInSpawnPoint(randomSpawnPointNumber);

        SpawnEntity(spawnPosition);
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

    private void SpawnEntity(Vector3 spawnPosition)
    {
        Instantiate(entityPrefab, spawnPosition, Quaternion.identity);
    }
        
}
