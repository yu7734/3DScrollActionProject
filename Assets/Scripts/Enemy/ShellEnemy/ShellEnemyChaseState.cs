using UnityEngine;

public class ShellEnemyChaseState : PlayerStateBase
{
    private SightCheckerManager sightCheck;
    public ShellEnemyChaseState(ShellEnemyState shellEnemyState) : base(shellEnemyState)
    {

    }
    public override void Enter()
    {

    }
    public override void Update()
    {
        shellEnemyState.Move();//移動

        if (!sightCheck.IsRock())//視界がプレイヤーから外れたら待機ポイントに戻るステートに変更
        {
            shellEnemyState.SwicthState(typeof(ShellEnemyBackState));
        }

        shellEnemyState.AttackRay();
    }
    public override void Exit()
    {

    }
}
