using UnityEngine;

public class PlayerJumpState : PlayerStateBase
{
    public PlayerJumpState(PlayerMovementStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        //ジャンプステートに入ったらジャンプ
        Jump();
    }

    public override void Update()
    {
        //重力
        //stateMachine.playerDirection.y += stateMachine.gravity * Time.deltaTime;
        //ジャンプ中でも移動
        stateMachine.PlayerMove();

        //地面に着いたら待機ステートに遷移
        if (!stateMachine.GetCharacterController.isGrounded) return;
        if (stateMachine._playerInput.inputMove.x != 0)
            stateMachine.SwicthState(typeof(PlayerMoveState));
        else
            stateMachine.SwicthState(typeof(PlayerIdleState));
    }

    public override void Exit()
    {

    }

    private void Jump()
    {
        stateMachine.playerDirection.y = Mathf.Sqrt(stateMachine.playerJumpPower * -1 * stateMachine.gravity);
        stateMachine.GetSetFallGround = null;
        //stateMachine.characterController.Move(stateMachine.playerDirection);
    }
}
