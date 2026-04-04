using UnityEngine;

public class Architect : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int healthPerInterval = 10;
    [SerializeField] private float secondsPerInterval = 1f;

    private float timeSinceHealed = 0f;

    private void Update()
    {
        if (!EnemySpawner.main.IsWaveActive()) return;

        timeSinceHealed += Time.deltaTime;

        if (timeSinceHealed >= secondsPerInterval)
        {
            Tower.main.HealDamage(healthPerInterval);
            timeSinceHealed = 0f;
        }
    }
}
