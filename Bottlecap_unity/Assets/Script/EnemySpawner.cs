using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    // Default to spawning on intself.
    public float spawnRadius = 0f;
    public List<GameObject> enemies;
    public bool spawnRandomEnemy;
    public Enums.ELEMENT_TYPES enemiesToSpawn; // Used if spawnRandom is false.
    public bool spawnRandomTime;
    public float spawnFrequencySeconds;
    public float spawnFrequencyVarianceSeconds; // Used if spawnRandomTime is true.

    private GameObject _enemyToSpawn;
    private Vector3 _currentPosition;
    private Random _random;
    
    void Start()
    {
        _currentPosition = transform.position;
        _random = new Random();
        
        // Find the enemy that needs to be spawned if random is not selected.
        if (!spawnRandomEnemy)
        {
            foreach (GameObject enemyObject in enemies)
            {
                Character character = enemyObject.GetComponent<Character>();
            
                if (character.characterElement == enemiesToSpawn)
                {
                    _enemyToSpawn = enemyObject;
                    break;
                }
            }
        }

        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (spawnRandomEnemy)
            {
                GameObject toSpawn = enemies[_random.Next(enemies.Count)];
                if (spawnRadius == 0f)
                {
                    Instantiate(toSpawn, transform);
                }
                else
                {
                    Instantiate(toSpawn, GetRandomSpawnLocation(), GetRandomRotation());
                }
            }
            else
            {
                if (spawnRadius == 0f)
                {
                    Instantiate(_enemyToSpawn, transform);
                }
                else
                {
                    Instantiate(_enemyToSpawn, GetRandomSpawnLocation(), GetRandomRotation());
                }
            }

            float waitTime = spawnFrequencySeconds;
        
            if (spawnRandomTime)
            {
                // If the seconds < 0 there is some undefined behavior (spawns more than 1 suddenly).
                waitTime = UnityEngine.Random.Range(Mathf.Max(waitTime - spawnFrequencyVarianceSeconds, 0),
                    Mathf.Max(waitTime + spawnFrequencyVarianceSeconds, 0));
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    private void OnDrawGizmos()
    {
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.down, spawnRadius);
    }

    private Vector3 GetRandomSpawnLocation()
    {
        float currentX = _currentPosition.x;
        float currentZ = _currentPosition.z;

        return new Vector3(
            UnityEngine.Random.Range(currentX - spawnRadius, currentX + spawnRadius),
            1f,
            UnityEngine.Random.Range(currentZ - spawnRadius, currentZ + spawnRadius)
        );
    }

    private Quaternion GetRandomRotation()
    {
        return new Quaternion(0f, UnityEngine.Random.Range(0f, 360f), 0f, 1f);
    }
}
