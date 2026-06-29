using UnityEngine;

public class PlayerMoveState : PlayerStateBase
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        //歩くアニメーション
        stateMachine.CAnima("Walk", true);
    }

    public override void Update()
    {
        PlayerMove();
    }

    public override void Exit()
    {
        stateMachine.CAnima("Walk", false);
    }

    private void PlayerMove()
    {
        //入力に応じて移動
        var moveVelocity = new Vector3(stateMachine._playerInput._inputMove.x * stateMachine.playerMoveSpeed * Time.deltaTime, 0, 0);
        stateMachine.characterController.Move(moveVelocity);

        //if (stateMachine._playerInput._inputMove.x < 0) 
    }
}
