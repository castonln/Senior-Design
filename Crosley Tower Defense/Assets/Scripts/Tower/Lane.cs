using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Lane : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private LayerMask laneMask;

    private List<GameObject> enemies = new List<GameObject>();

    public Transform SpawnPoint => spawnPoint;

    public Transform GetTargetPoint()
    {
        if (enemies.Count == 1) return targetPoint;

        return enemies[0].transform;
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
        int layer = (int)Mathf.Log(laneMask.value, 2);

        foreach (Transform child in enemy.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = layer;
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public LayerMask GetLaneMask()
    {
        return laneMask;
    }
}
