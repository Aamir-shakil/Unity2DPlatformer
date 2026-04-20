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
    }

    public void Exit()
    {
    }

    public void LogicUpdate()
    {
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