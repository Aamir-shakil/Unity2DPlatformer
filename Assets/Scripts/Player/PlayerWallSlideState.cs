using UnityEngine;

public class PlayerWallSlideState : IPlayerState
{
    private readonly PlayerMovement player;

    public PlayerWallSlideState(PlayerMovement player)
    {
        this.player = player;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
        player.StartWallJumpWindow();

        if (player.IsGrounded)
        {
            player.StateMachine.ChangeState(player.IdleState);
            return;
        }

        if (!player.CanWallSlide())
        {
            player.StateMachine.ChangeState(player.AirState);
        }
    }

    public void PhysicsUpdate()
    {
        player.MoveHorizontally();
        player.ApplyWallSlide();
    }

    public void OnJumpPressed()
    {
        if (player.CanWallJump())
        {
            player.PerformWallJump();
            player.StateMachine.ChangeState(player.WallJumpState);
        }
    }

    public void OnJumpReleased()
    {
    }
}