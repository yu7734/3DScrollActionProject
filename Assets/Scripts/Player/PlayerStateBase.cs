//using UnityEngine;

public abstract class PlayerStateBase : IPlayerState
{
    protected PlayerMovementStateMachine stateMachine;
    protected PlayerDamageStateMachine damageStateMachine;

    //セットするコンストラクタ
    public PlayerStateBase(PlayerMovementStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public PlayerStateBase(PlayerDamageStateMachine stateMachine)
    {
        this.damageStateMachine = stateMachine;
    }

    //abstractメソッドは継承先で絶対に実装しなければならない
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
