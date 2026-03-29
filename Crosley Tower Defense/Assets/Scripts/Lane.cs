using UnityEngine;

public class Lane : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform targetPoint;

    public Transform SpawnPoint => spawnPoint;
    public Transform TargetPoint => targetPoint;
}
