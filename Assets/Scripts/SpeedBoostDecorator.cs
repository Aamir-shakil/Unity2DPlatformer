/// <summary>
/// Decorator that temporarily enhances player movement speed
/// without modifying the base player movement implementation.
/// </summary>
public class SpeedBoostDecorator : PlayerEffectDecorator
{
    private readonly float speedMultiplier;

    public SpeedBoostDecorator(IPlayerEffect wrappedEffect, float speedMultiplier) : base(wrappedEffect)
    {
        this.speedMultiplier = speedMultiplier;
    }

    public override float GetSpeedMultiplier()
    {
        return wrappedEffect.GetSpeedMultiplier() * speedMultiplier;
    }
}