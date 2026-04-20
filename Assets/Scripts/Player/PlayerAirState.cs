using UnityEngine;

public class PlayerAirState : IPlayerState
{
    private readonly PlayerMovement player;

    public PlayerAirState(PlayerMovement player)
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
        if (player.IsGrounded)
        {
            if (Mathf.Abs(player.HorizontalMovement) > 0.01f)
                player.StateMachine.ChangeState(player.MoveState);
            else
                player.StateMachine.ChangeState(player.IdleState);

            return;
        }

        if (player.CanWallSlide())
        {
            player.StateMachine.ChangeState(player.WallSlideState);
        }
    }

    public void PhysicsUpdate()
    {
        player.MoveHorizontally();
    }

    public void OnJumpPressed()
    {
        if (player.CanJump())
        {
            player.PerformJump();
        }
    }

    public void OnJumpReleased()
    {
        player.CutJumpShort();
    }
}