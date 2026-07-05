using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        //ジャンプステートに入ったらジャンプ
        Jump();
    }

    public override void Update()
    {
        //重力
        stateMachine.playerDirection.y -= stateMachine.gravity * Time.deltaTime;
        //ジャンプ中でも移動
        stateMachine.PlayerMove();

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
