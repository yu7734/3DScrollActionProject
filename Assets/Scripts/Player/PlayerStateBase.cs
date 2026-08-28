//using UnityEngine;

using UnityEngine;

public abstract class PlayerStateBase : ICharactorState
{
    protected PlayerMovementStateMachine stateMachine;
    protected PlayerDamageStateMachine damageStateMachine;
    protected ShellEnemyState shellEnemyState;

    //セットするコンストラクタ
    public PlayerStateBase(PlayerMovementStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public PlayerStateBase(PlayerDamageStateMachine stateMachine)
    {
        this.damageStateMachine = stateMachine;
    }

    public PlayerStateBase (ShellEnemyState stateMachine)
    {
        this.shellEnemyState = stateMachine;
    }

    //abstractメソッドは継承先で絶対に実装しなければならない
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

    //仮想メソッドを用意し、必要なステートだけにオーバーライドする
    public virtual void OnControllerColliderHit(ControllerColliderHit hit) { } 
}
