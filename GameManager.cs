using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Referensi untuk UI text skor
    public TextMeshProUGUI timeText;   // Referensi untuk UI text waktu
    public TextMeshProUGUI endGameText; // UI untuk menampilkan pesan akhir (win/lose)

    private int score = 0;
    private float timeRemaining = 60f;
    private bool gameOver = false;

    void Start()
    {
        // Pastikan UI direset pada awal game
        if (scoreText != null) scoreText.text = "Score: 0";
        if (timeText != null) timeText.text = "Time: 60";
        if (endGameText != null) endGameText.text = ""; // Tidak ada pesan di awal
    }

    void Update()
    {
        if (gameOver)
            return;  // Jangan update jika game sudah selesai

        // Update waktu setiap frame
        timeRemaining -= Time.deltaTime;

        // Pastikan waktu tidak menjadi negatif
        if (timeRemaining < 0) timeRemaining = 0;

        // Update teks waktu
        if (timeText != null)
        {
            timeText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
        }

        // Update skor
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        // Cek apakah waktu habis atau skor mencapai 10
        if (score >= 10)
        {
            GameWin();  // Pemain menang jika skor mencapai 10
        }
        else if (timeRemaining == 0)
        {
            GameLose();  // Pemain kalah jika waktu habis tanpa mencapai 10
        }
    }

    // Fungsi untuk menambah skor
    public void AddScore(int value)
    {
        if (!gameOver)
        {
            score += value;
        }
    }

    // Fungsi untuk menang
    void GameWin()
    {
        if (!gameOver)
        {
            gameOver = true;  // Menandakan game selesai
            if (endGameText != null)
            {
                endGameText.text = "You Win!";  // Menampilkan pesan menang
            }
            Time.timeScale = 0;  // Menjeda seluruh waktu di game
            Debug.Log("You Win!");
        }
    }

    // Fungsi untuk kalah
    void GameLose()
    {
        if (!gameOver)
        {
            gameOver = true;  // Menandakan game selesai
            if (endGameText != null)
            {
                endGameText.text = "Game Over! You Lose.";  // Menampilkan pesan kalah
            }
            Time.timeScale = 0;  // Menjeda seluruh waktu di game
            Debug.Log("Game Over! You Lose.");
        }
    }
}
