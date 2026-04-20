/// <summary>
/// Abstract decorator for player effects.
/// Wraps another player effect and extends its behaviour.
/// </summary>
public abstract class PlayerEffectDecorator : IPlayerEffect
{
    protected IPlayerEffect wrappedEffect;

    protected PlayerEffectDecorator(IPlayerEffect wrappedEffect)
    {
        this.wrappedEffect = wrappedEffect;
    }

    public virtual float GetSpeedMultiplier()
    {
        return wrappedEffect.GetSpeedMultiplier();
    }
}