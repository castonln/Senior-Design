using UnityEngine;

public class StudentSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject studentPrefab;
    [SerializeField] GameObject studentSpawnPoint;
    [SerializeField] GameObject studentGroup;
    public void SpawnStudent()
    {
        GameObject student = Instantiate(
                studentPrefab,
                studentSpawnPoint.transform.position + Vector3.up,
                studentSpawnPoint.transform.rotation,
                studentGroup.transform
            );
    }
}
