using System;
/// <summary>
/// Central event hub implementing the Observer pattern.
/// 
/// Publisher objects broadcast gameplay events without direct
/// references to subscribers. UI and controller systems listen
/// and react independently, reducing coupling and improving
/// maintainability.
/// </summary>

public static class GameEvents
{
    // Raised when a collectible gem is obtained.
    public static event Action<int> OnGemCollected;

    // Raised when player health changes.
    public static event Action<int> OnHealthChanged;

    // Raised when player health reaches zero.
    public static event Action OnPlayerDied;

    // Raised when level completion conditions are met.
    public static event Action OnLevelCompleted;

    public static void GemCollected(int amount)
    {
        OnGemCollected?.Invoke(amount);
    }

    public static void HealthChanged(int currentHealth)
    {
        OnHealthChanged?.Invoke(currentHealth);
    }

    public static void PlayerDied()
    {
        OnPlayerDied?.Invoke();
    }

    public static void LevelCompleted()
    {
        OnLevelCompleted?.Invoke();
    }
}