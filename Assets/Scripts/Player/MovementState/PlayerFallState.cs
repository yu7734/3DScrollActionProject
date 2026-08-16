using UnityEngine;

public class PlayerFallState : PlayerStateBase
{

    public PlayerFallState(PlayerMovementStateMachine stateMachine) : base(stateMachine) { }
    
    public override void Enter()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        //重力で落下
        //落下中でも移動出来るように
        stateMachine.playerDirection.y -= stateMachine.gravity * Time.deltaTime;
        stateMachine.PlayerMove();

        //地面に着いたら待機ステートに遷移
        if (!stateMachine.characterController.isGrounded) return;
            stateMachine.SwicthState(typeof(PlayerIdleState));
    }

    public override void Exit() { }
}
