using UnityEngine;

public class DeadState : PlayerStateBase
{
    public DeadState(PlayerDamageStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        damageStateMachine.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public override void Exit()
    {

    }
}
