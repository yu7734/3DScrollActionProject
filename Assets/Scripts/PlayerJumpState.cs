using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Jump();
    }

    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }

    private void Jump()
    {
        stateMachine.playerDirection.y = stateMachine.playerJumpPower;
        stateMachine.characterController.Move(stateMachine.playerDirection);
    }
}
