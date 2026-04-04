using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameOverScreen gameOverScreen;

    private void OnEnable()
    {
        Tower.OnFloorStackEmpty += GameOver;
    }

    private void OnDisable()
    {
        Tower.OnFloorStackEmpty -= GameOver;
    }

    private void GameOver()
    {
        gameOverScreen.Enable();
    }
}
