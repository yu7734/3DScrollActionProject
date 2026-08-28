using UnityEngine;

public class ShellEnemyIdleState : PlayerStateBase
{
    private SightCheckerManager sightCheck;
    public ShellEnemyIdleState (ShellEnemyState shellEnemyState) : base (shellEnemyState)
    {

    }
    public override void Enter()
    {
        
    }
    public override void Update()
    {
        if (!sightCheck.IsRock()) return;
        shellEnemyState.SwicthState(typeof(ShellEnemyChaseState));
    }
    public override void Exit()
    {
        
    }
}
