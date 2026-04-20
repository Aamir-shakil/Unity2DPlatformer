using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls overall game flow including progress tracking,
/// win state, and game over UI.
///
/// Acts as an Observer by subscribing to gameplay events
/// published through GameEvents.
/// </summary>

public class GameController : MonoBehaviour
{
    private int progressAmount;
    public Slider progressSlider;

    public GameObject gameOverScreen;
    public TMP_Text survivedText;

    private void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        gameOverScreen.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnGemCollected += IncreaseProgressAmount;
        GameEvents.OnPlayerDied += ShowGameOverScreen;
        GameEvents.OnLevelCompleted += ShowWinScreen;
    }

    private void OnDisable()
    {
        GameEvents.OnGemCollected -= IncreaseProgressAmount;
        GameEvents.OnPlayerDied -= ShowGameOverScreen;
        GameEvents.OnLevelCompleted -= ShowWinScreen;
    }

    private void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;

        if (progressAmount >= 100)
        {
            GameEvents.LevelCompleted();
        }
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        survivedText.text = "You Survived: " + Time.timeSinceLevelLoad.ToString("F1") + " Seconds";
        Time.timeScale = 0f;
    }

    private void ShowWinScreen()
    {
        gameOverScreen.SetActive(true);
        survivedText.text = "You Win!\nYou completed the game in "
            + Time.timeSinceLevelLoad.ToString("F1") + " seconds";
        Time.timeScale = 0f;
    }

    public void ResetGame()
    {
        gameOverScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}