using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    public int worth = 5;

    public void Collect()
    {
        GameEvents.GemCollected(worth);
        Destroy(gameObject);
    }
}