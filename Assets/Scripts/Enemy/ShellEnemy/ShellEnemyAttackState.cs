using UnityEngine;

public class ShellEnemyAttackState : PlayerStateBase
{
    public ShellEnemyAttackState(ShellEnemyState shellEnemyState) : base(shellEnemyState)
    {

    }
    public override void Enter()
    {
        shellEnemyState.AnimaChange("isAttack", true);
    }
    public override void Update()
    {

    }
    public override void Exit()
    {
        shellEnemyState.AnimaChange("isAttack", true);
    }
}
