//using UnityEngine;
//using UnityEngine.InputSystem;

using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
    }

    public override void Update()
    {
        stateMachine.CAnima("Attack", true);
    }

    public override void Exit()
    {
        stateMachine.CAnima("Attack", false);
    }
}
