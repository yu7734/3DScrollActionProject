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
        stateMachine.playerDirection.y += stateMachine.gravity * Time.deltaTime;
        //ジャンプ中でも移動
        stateMachine.PlayerMove();

        if (stateMachine.GetCharacterController.isGrounded)
            stateMachine.SwicthState(typeof(PlayerIdleState));
    }

    public override void Exit()
    {

    }

    private void Jump()
    {
        stateMachine.playerDirection.y = Mathf.Sqrt(stateMachine.playerJumpPower * -1 * stateMachine.gravity);
        //stateMachine.characterController.Move(stateMachine.playerDirection);
    }
}
