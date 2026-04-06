using TMPro;
using UnityEngine;

public class WaveNumber : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveNumberUI;
    private void OnEnable()
    {
        EnemySpawner.OnWaveEnd += SetWaveNumber;
    }

    private void OnDisable()
    {
        EnemySpawner.OnWaveEnd -= SetWaveNumber;
    }

    private void SetWaveNumber()
    {
        waveNumberUI.text = EnemySpawner.main.GetWaveTotalUI().ToString();
    }
}
