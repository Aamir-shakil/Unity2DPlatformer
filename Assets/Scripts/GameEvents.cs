using System;

public static class GameEvents
{
    public static event Action<int> OnGemCollected;
    public static event Action<int> OnHealthChanged;
    public static event Action OnPlayerDied;
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