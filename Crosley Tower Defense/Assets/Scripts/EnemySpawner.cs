using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] private Lane rightLane;
    [SerializeField] private Lane leftLane;
    [SerializeField] private Lane topRightLane;
    [SerializeField] private Lane topLeftLane;

    [Header("References")]
    [SerializeField] private Transform shootTarget;
    [SerializeField] private GameObject enemyGroup;
    [SerializeField] private WaveData[] waves;

    private WaveData wave;
    private int currentWaveIndex = 0;
    private int enemiesAlive = 0;
    private bool isSpawning = false;
    private bool isWaveActive = false;

    private SubWaveInfo subWave;
    private int currentSubWaveIndex = 0;
    private float timeSinceLastSpawn = 0f;
    private int enemiesToSpawnInSubwave = 0;

    public static event Action OnWaveEnd;

    private void Update()
    {
        if (!isWaveActive) return;

        if (!isSpawning)
        {
            if (enemiesAlive == 0) WaveEnd();
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= subWave.secondsBetweenEnemies && enemiesToSpawnInSubwave > 0)
        {
            GameObject enemy = SpawnEnemy(subWave.enemyPrefab, GetSpawnPointTransform(subWave.spawnSide));

            enemiesToSpawnInSubwave--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesToSpawnInSubwave == 0)
        {
            StartNextSubWave();
        }

    }

    public void WaveStart()
    {
        wave = waves[currentWaveIndex];
        subWave = wave.subWaves[currentSubWaveIndex];
        enemiesToSpawnInSubwave = subWave.count;
        isSpawning = true;
        isWaveActive = true;
    }

    private void WaveEnd()
    {
        isWaveActive = false;
        isSpawning = false;
        currentWaveIndex++;
        currentSubWaveIndex = 0;
        timeSinceLastSpawn = 0f;
        OnWaveEnd?.Invoke();
    }

    private void StartNextSubWave()
    {
        timeSinceLastSpawn = 0f;
        currentSubWaveIndex++;
        if (currentSubWaveIndex >= wave.subWaves.Length)
        {
            isSpawning = false;
        } else
        {
            subWave = wave.subWaves[currentSubWaveIndex];
            enemiesToSpawnInSubwave = subWave.count;
        }
    }
    private Transform GetSpawnPointTransform(SpawnSide side)
    {
        return side switch
        {
            SpawnSide.left => leftLane.SpawnPoint,
            SpawnSide.right => rightLane.SpawnPoint,
            SpawnSide.topRight => topRightLane.SpawnPoint,
            SpawnSide.topLeft => topLeftLane.SpawnPoint,
            _ => leftLane.SpawnPoint
        };
    }

    private Transform GetTargetPointTransform(SpawnSide side)
    {
        return side switch
        {
            SpawnSide.left => leftLane.TargetPoint,
            SpawnSide.right => rightLane.TargetPoint,
            SpawnSide.topRight => topRightLane.TargetPoint,
            SpawnSide.topLeft => topLeftLane.TargetPoint,
            _ => leftLane.TargetPoint
        };
    }
    private GameObject SpawnEnemy(GameObject prefab, Transform spawnPoint)
    {
        GameObject enemy = Instantiate(
            prefab,
            spawnPoint.position + Vector3.up,
            spawnPoint.rotation,
            enemyGroup.transform
           );

        enemy.GetComponent<EnemyMovement>().SetTarget(GetTargetPointTransform(subWave.spawnSide));
        enemy.GetComponent<Triceracopter>().SetTarget(shootTarget);

        if (subWave.spawnSide == SpawnSide.left || subWave.spawnSide == SpawnSide.topLeft)
            FlipHorizontally(enemy.transform);
        return enemy;
    }

    public void FlipHorizontally(Transform objectTransform)
    {
        Vector3 newScale = objectTransform.localScale;
        newScale.x *= -1;
        objectTransform.localScale = newScale;
    }
}
