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
        stateMachine.playerDirection.y -= stateMachine.gravity * Time.deltaTime;
        stateMachine.characterController.Move(stateMachine.playerDirection * Time.deltaTime);

        if (stateMachine.characterController.isGrounded)
            stateMachine.SwicthState(typeof(PlayerIdleState));
    }

    public override void Exit()
    {

    }

    private void Jump()
    {
        stateMachine.playerDirection.y = stateMachine.playerJumpPower;
        //stateMachine.characterController.Move(stateMachine.playerDirection);
    }
}
