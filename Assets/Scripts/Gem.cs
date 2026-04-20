using UnityEngine;

/// <summary>
/// Collectible gem item.
/// 
/// Demonstrates Observer pattern usage by publishing a gem
/// collection event through GameEvents rather than directly
/// modifying UI or progress systems.
/// </summary>

public class Gem : MonoBehaviour, IItem
{
    public int worth = 5;

    public void Collect()
    {
        GameEvents.GemCollected(worth);
        Destroy(gameObject);
    }
}