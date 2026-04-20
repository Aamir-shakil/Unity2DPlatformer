using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class GameControllerTests
{
    [UnityTest]
    public IEnumerator GemCollected_IncreasesProgressBar()
    {
        GameObject controllerObj = new GameObject();
        GameController controller = controllerObj.AddComponent<GameController>();

        GameObject sliderObj = new GameObject();
        Slider slider = sliderObj.AddComponent<Slider>();

        controller.progressSlider = slider;
        controller.gameOverScreen = new GameObject();

        yield return null;

        float before = slider.value;

        GameEvents.GemCollected(5);

        yield return null;

        float after = slider.value;

        Assert.Greater(after, before);
    }
}