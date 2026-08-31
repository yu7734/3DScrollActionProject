using UnityEngine;

public class ShellEnemyBackState : PlayerStateBase
{
    public ShellEnemyBackState(ShellEnemyState shellEnemyState) : base(shellEnemyState)
    {

    }
    public override void Enter()
    {

    }
    public override void Update()
    {
        shellEnemyState.Move();

        var enemyPosition = shellEnemyState.transform.position.x;
        var idlePoint = shellEnemyState.idlePointTransform.position.x;
        //待機ポイントが右か左にあるかによって向きを変える
        if (enemyPosition < idlePoint) 
            shellEnemyState.MoveDirection = Vector2.right;
        else
            shellEnemyState.MoveDirection = Vector2.left;

        //視界に入ったら追跡ステート
        if (shellEnemyState.sightCheckerManager.IsRock()) shellEnemyState.SwicthState(typeof(ShellEnemyChaseState));

        //戻ったら待機ステート
        if (idlePoint - 1 < enemyPosition && enemyPosition < idlePoint + 1)
            shellEnemyState.SwicthState(typeof(ShellEnemyIdleState));
    }
    public override void Exit()
    {

    }
}
