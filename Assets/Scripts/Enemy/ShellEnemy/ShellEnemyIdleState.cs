using Unity.VisualScripting;
using UnityEngine;

public class ShellEnemyIdleState : PlayerStateBase
{
    public ShellEnemyIdleState (ShellEnemyState shellEnemyState) : base (shellEnemyState)
    {

    }
    public override void Enter()
    {
        
    }
    public override void Update()
    {
        if (shellEnemyState.sightCheckerManager.IsRock())
            shellEnemyState.SwicthState(typeof(ShellEnemyChaseState));
    }
    public override void Exit()
    {
        
    }
}
