using UnityEngine;

public class EndAttackAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMovementStateMachine moveStateMachine;

    private void EndAttack()
    {
        moveStateMachine.SwicthState(typeof(PlayerIdleState));
    }
}
