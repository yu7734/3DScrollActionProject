//using UnityEngine;

public abstract class PlayerStateBase : IPlayerState
{
    protected PlayerStateMachine stateMachine;

    //セットするコンストラクタ
    public PlayerStateBase(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    //abstractメソッドは継承先で絶対に実装しなければならない
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}
