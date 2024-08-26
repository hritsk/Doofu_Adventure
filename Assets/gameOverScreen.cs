using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        // Reload the main game scene
        SceneManager.LoadScene("MainGameScene");
    }

    public void QuitGame()
    {
        // Quit the game (works in built game)
        Application.Quit();
    }
}
