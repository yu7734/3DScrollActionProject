using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : PlayerStateBase
{
    
    public PlayerIdleState(PlayerMovementStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        
    }

    public override void Update()
    {
        stateMachine.PlayerMove();
        if (stateMachine.GetCharacterController.isGrounded) return;

        //地面に着いていなかったら落下ステートに遷移
        stateMachine.SwicthState(typeof(PlayerFallState));
    }

    public override void Exit()
    {

    }
}
