
/// <summary>
/// Component interface for player effect modifiers.
/// Supports the Decorator pattern by allowing dynamic effect extension.
/// </summary>
public interface IPlayerEffect
{
    float GetSpeedMultiplier();
}