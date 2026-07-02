using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerStateBase
{
    
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        
    }

    public override void Update()
    {
        if (stateMachine.characterController.isGrounded)
            return;

        stateMachine.playerDirection.y -= stateMachine.gravity * Time.deltaTime;
        stateMachine.characterController.Move(stateMachine.playerDirection * Time.deltaTime);
    }

    public override void Exit()
    {

    }
}
