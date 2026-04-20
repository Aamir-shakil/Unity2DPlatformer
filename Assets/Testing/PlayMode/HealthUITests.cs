using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class HealthUITests
{
    [UnityTest]
    public IEnumerator HealthChanged_UpdatesHeartColours()
    {
        // Arrange
        GameObject uiObj = new GameObject();
        HealthUI healthUI = uiObj.AddComponent<HealthUI>();

        GameObject prefabObj = new GameObject();
        Image prefabImage = prefabObj.AddComponent<Image>();

        healthUI.heartPrefab = prefabImage;

        healthUI.fullHeartSprite = null;
        healthUI.emptyHeartSprite = null;

        yield return null; // allow component setup

        healthUI.SetMaxHearts(3);

        yield return null;

        // Act
        GameEvents.HealthChanged(1);

        yield return null;

        // Assert
        Image[] hearts = uiObj.GetComponentsInChildren<Image>();

        Assert.AreEqual(3, hearts.Length);
        Assert.AreEqual(Color.red, hearts[0].color);
        Assert.AreEqual(Color.white, hearts[1].color);
        Assert.AreEqual(Color.white, hearts[2].color);
    }
}