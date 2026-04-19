using System;
using UnityEngine;

public class SpeedItem : MonoBehaviour, IItem
{
    public static event Action<float> OnSpeedCollected;
    public float speedMultiplier = 2.2f;
    public void Collect()
    {
        OnSpeedCollected?.Invoke(speedMultiplier);
        Destroy(gameObject);

    }

 
}
