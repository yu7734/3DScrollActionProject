using UnityEngine;

public class NormalState : PlayerStateBase
{
    public NormalState(PlayerDamageStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "Enemy") return;//“G‚É“–‚½‚Á‚½‚ç
        damageStateMachine.PlayerHP--;//HP‚ðŒ¸‚ç‚·
        Debug.Log(damageStateMachine.PlayerHP);
        if (damageStateMachine.PlayerHP <= 0)
            damageStateMachine.SwicthState(typeof(DeadState));//‘Ì—Í‚ª0‚È‚çŽ€–S
        else
            damageStateMachine.SwicthState(typeof(DamagedState));
    }

    private void PlayerDie()
    {
        if (!(damageStateMachine.PlayerHP <= 0)) return;
        damageStateMachine.SwicthState(typeof(DeadState));//‘Ì—Í‚ª0‚È‚çŽ€–S
    }
}
