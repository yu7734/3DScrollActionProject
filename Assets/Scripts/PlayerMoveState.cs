using UnityEngine;
using UnityEngine.EventSystems;

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
        var moveVelocity = new Vector3(stateMachine._playerInput._inputMove.x * stateMachine.playerMoveSpeed, stateMachine.playerDirection.y, 0);

        //入力に応じて向きを変える
        if (stateMachine._playerInput._inputMove.x < 0) 
            stateMachine._playerObject.transform.eulerAngles = new Vector3(0, -90, 0);
        else if (stateMachine._playerInput._inputMove.x > 0) 
            stateMachine._playerObject.transform.eulerAngles = new Vector3(0, 90, 0);

        moveVelocity.y -= stateMachine.gravity * Time.deltaTime;

        stateMachine.characterController.Move(moveVelocity * Time.deltaTime);
    }
}
