using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerStateBase
{
    public PlayerMoveState(PlayerMovementStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        //歩くアニメーション
        stateMachine.CAnima("Walk", true);
    }

    public override void Update()
    {
        stateMachine.PlayerMove();

        //地面についていなかったら落下ステートに切り替え
        if (!stateMachine.characterController.isGrounded)
            stateMachine.SwicthState(typeof(PlayerFallState));
    }

    public override void Exit()
    {
        stateMachine.CAnima("Walk", false);
    }
}
