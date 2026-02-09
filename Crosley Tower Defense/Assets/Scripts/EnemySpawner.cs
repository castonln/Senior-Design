using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject enemySpawnPoint;
    [SerializeField] GameObject enemyGroup;

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(
                enemyPrefab,
                enemySpawnPoint.transform.position + Vector3.up,
                enemySpawnPoint.transform.rotation,
                enemyGroup.transform
            );
    }
}
