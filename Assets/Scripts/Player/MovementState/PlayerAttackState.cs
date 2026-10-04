//using UnityEngine;
//using UnityEngine.InputSystem;

using UnityEngine;

public class PlayerAttackState : PlayerStateBase
{
    public PlayerAttackState(PlayerMovementStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        //軌跡エフェクトの描画をONにして、攻撃アニメーション再生
        stateMachine.GetSetTrailRenderer.emitting = true;
        stateMachine.CAnima("Attack", true);
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        stateMachine.GetSetTrailRenderer.emitting = false;
        stateMachine.CAnima("Attack", false);
    }
}
