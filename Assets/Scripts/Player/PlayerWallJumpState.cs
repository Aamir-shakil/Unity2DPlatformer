using UnityEngine;

public class PlayerWallJumpState : IPlayerState
{
    private readonly PlayerMovement player;

    public PlayerWallJumpState(PlayerMovement player)
    {
        this.player = player;
    }

    public void Enter()
    {
        player.BeginWallJumpState();
    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
        player.UpdateWallJumpTimer();

        if (!player.IsWallJumping)
        {
            player.StateMachine.ChangeState(player.AirState);
        }
    }

    public void PhysicsUpdate()
    {
    }

    public void OnJumpPressed()
    {
    }

    public void OnJumpReleased()
    {
        player.CutJumpShort();
    }
}