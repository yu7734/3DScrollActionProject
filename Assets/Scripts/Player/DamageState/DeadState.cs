using UnityEngine;

public class DeadState : PlayerStateBase
{
    public DeadState(PlayerDamageStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        //プレイヤーを消し、ゲームオーバー
        Debug.Log("ゲームオーバー");
        damageStateMachine.gameObject.SetActive(false);
        damageStateMachine.GetSetGameManager.GetSetIsGameOver = true;
        Debug.Log(damageStateMachine.GetSetGameManager.GetSetIsGameOver);
        
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}
