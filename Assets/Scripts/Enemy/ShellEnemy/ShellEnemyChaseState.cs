using UnityEngine;

public class ShellEnemyChaseState : PlayerStateBase
{
    public ShellEnemyChaseState(ShellEnemyState shellEnemyState) : base(shellEnemyState)
    {

    }
    public override void Enter()
    {
        shellEnemyState.AnimaChange("isChase", true);
    }
    public override void Update()
    {
        shellEnemyState.Move();//移動

        if (!shellEnemyState.sightCheckerManager.IsRock())//視界がプレイヤーから外れたら待機ポイントに戻るステートに変更
            shellEnemyState.SwicthState(typeof(ShellEnemyBackState));

        shellEnemyState.AttackRay();
    }
    public override void Exit()
    {
        shellEnemyState.AnimaChange("isChase", false);
    }
}
