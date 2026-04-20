public interface IPlayerState
{
    void Enter();
    void Exit();
    void LogicUpdate();
    void PhysicsUpdate();
    void OnJumpPressed();
    void OnJumpReleased();
}