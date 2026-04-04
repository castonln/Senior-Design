using UnityEngine;
using UnityEngine.UI;

public class StartWaveButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] EnemySpawner enemySpawner;

    public void StartWaveButtonClick()
    {
        enemySpawner.WaveStart();
        DisableWaveButton();
    }

    private void DisableWaveButton()
    {
        gameObject.GetComponentInParent<Button>().interactable = false;
    }

    private void EnableWaveButton()
    {
        gameObject.GetComponentInParent<Button>().interactable = true;
    }

    private void OnEnable()
    {
        EnemySpawner.OnWaveEnd += EnableWaveButton;
    }

    private void OnDisable()
    {
        EnemySpawner.OnWaveEnd -= EnableWaveButton;
    }
}
