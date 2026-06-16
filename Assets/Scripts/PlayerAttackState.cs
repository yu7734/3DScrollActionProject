//using UnityEngine;
//using UnityEngine.InputSystem;

using System.Diagnostics;

public class PlayerAttackState : PlayerStateBase
{
    PlayerObject _playerObject;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        _playerObject = new PlayerObject();
    }

    public override void Update()
    {
        _playerObject.CAnima("Attack", true);
    }

    public override void Exit()
    {
        _playerObject.CAnima("Attack", false);
    }
}
