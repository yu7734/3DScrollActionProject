using UnityEngine;

public class DeadState : PlayerStateBase
{
    public DeadState(PlayerDamageStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        //プレイヤーを消し、ゲームオーバー
        damageStateMachine.gameObject.SetActive(false);
        damageStateMachine.GetSetGameManager.GetSetIsGameOver = true;  
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}
