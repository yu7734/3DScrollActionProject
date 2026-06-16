using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackState : PlayerStateBase
{
    [SerializeField] private PlayerObject _playerObject;
    public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {

    }

    public override void Update()
    {
        _playerObject.CAnima("Attack", true);
    }

    public override void Exit()
    {
        _playerObject.CAnima("Attack", false);
    }

    private void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }

        if (context.performed)
        {
            _playerObject.CAnima("Attack", true);
        }

        if (context.canceled)
        {
            _playerObject.CAnima("Attack", false);
        }
    }
}
