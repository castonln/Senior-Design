using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject upgradeMenu;

    public void Enable()
    {
        gameObject.SetActive(true);
        shopMenu.SetActive(false);
        upgradeMenu.SetActive(false);   
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
