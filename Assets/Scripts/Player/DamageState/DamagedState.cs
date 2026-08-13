using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DamagedState : PlayerStateBase
{
    const float flashInterval = 0.5f;//点滅の間隔

    public DamagedState(PlayerDamageStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        damageStateMachine.gameObject.layer = LayerMask.NameToLayer("PlayerDamage");//レイヤー変更
        Debug.Log(damageStateMachine.gameObject.layer);
        damageStateMachine.StartCoroutine(Damaged());
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void Exit()
    {

    }

    IEnumerator Damaged()
    {
        //点滅ループ開始
        for (int i = 0; i < 3; ++i)
        {
            yield return new WaitForSeconds(flashInterval);//flashIntervalを待ってから
            damageStateMachine.renderer.enabled = false;//rendererを非表示

            yield return new WaitForSeconds(flashInterval);//flashIntervalを待ってから
            damageStateMachine.renderer.enabled = true;//rendererを表示
        }

        damageStateMachine.gameObject.layer = LayerMask.NameToLayer("Default");//レイヤー変更
        Debug.Log(damageStateMachine.gameObject.layer);
        damageStateMachine.SwicthState(typeof(NormalState));
    }
}
