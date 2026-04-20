/// <summary>
/// Base player effect with no modification applied.
/// Serves as the concrete component in the Decorator pattern.
/// </summary>
public class BasePlayerEffect : IPlayerEffect
{
    public float GetSpeedMultiplier()
    {
        return 1f;
    }
}