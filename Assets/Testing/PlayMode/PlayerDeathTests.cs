using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

public class PlayerDeathTests
{
    [UnityTest]
    public IEnumerator PlayerDied_ShowsGameOverScreen()
    {
        // Arrange
        GameObject controllerObj = new GameObject();
        GameController controller = controllerObj.AddComponent<GameController>();

        GameObject gameOverObj = new GameObject();
        gameOverObj.SetActive(false);

        GameObject textObj = new GameObject();
        TMP_Text tmpText = textObj.AddComponent<TextMeshProUGUI>();

        controller.gameOverScreen = gameOverObj;
        controller.survivedText = tmpText;

        yield return null; // allow Start/OnEnable

        // Act
        GameEvents.PlayerDied();

        yield return null;

        // Assert
        Assert.IsTrue(gameOverObj.activeSelf);
    }
}