using UnityEngine;

public class FinancialAdvisor : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int moneyPerInterval = 10;
    [SerializeField] private float secondsPerInterval = 1f;

    private float timeSinceMoney = 0f;

    private void Update()
    {
        if (!EnemySpawner.main.IsWaveActive()) return;

        timeSinceMoney += Time.deltaTime;

        if (timeSinceMoney >= secondsPerInterval)
        {
            LevelManager.main.IncreaseCurrency(moneyPerInterval);
            timeSinceMoney = 0f;
        }
    }
}
