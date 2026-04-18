using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject gameOverScreen;
    public TMP_Text survivedText;

    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
        PlayerHealth.OnPlayerDied += GameOverScreen;
        gameOverScreen.SetActive(false);

    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        survivedText.text = "You Survived: " + Time.timeSinceLevelLoad + " Seconds";
        Time.timeScale = 0f; // Pause the game
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f; // Resume the game
    }
    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if(progressAmount >= 100)
        {
            gameOverScreen.SetActive(true);
            survivedText.text = "You Win!\n You completed the game in "
                + Time.timeSinceLevelLoad.ToString("F1")
                + " seconds";
            Time.timeScale = 0f; // Pause the game
        }
    }

    private void OnDestroy()
    {
        Gem.OnGemCollect -= IncreaseProgressAmount;
        PlayerHealth.OnPlayerDied -= GameOverScreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
