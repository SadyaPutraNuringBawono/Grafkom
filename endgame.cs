using UnityEngine;
using UnityEngine.SceneManagement;  // Untuk memuat ulang scene

public class GameOverMenu : MonoBehaviour
{
    public void RestartGame()
    {
        // Memuat ulang scene saat ini
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;  // Pastikan waktu game berjalan lagi
    }

    public void QuitGame()
    {
        // Keluar dari game (khusus di build)
        Application.Quit();
        Debug.Log("Game Closed");
    }
}
