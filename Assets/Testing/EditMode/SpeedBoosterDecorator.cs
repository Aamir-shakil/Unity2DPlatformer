using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class SpeedBoostDecoratorTests
{
    [Test]
    public void SpeedBoostDecorator_AppliesMultiplierCorrectly()
    {
        IPlayerEffect baseEffect = new BasePlayerEffect();
        IPlayerEffect boostedEffect = new SpeedBoostDecorator(baseEffect, 1.5f);

        float result = boostedEffect.GetSpeedMultiplier();

        Assert.AreEqual(1.5f, result);
    }

    [Test]
    public void BasePlayerEffect_ReturnsDefaultMultiplier()
    {
        IPlayerEffect baseEffect = new BasePlayerEffect();

        float result = baseEffect.GetSpeedMultiplier();

        Assert.AreEqual(1f, result);
    }
}
