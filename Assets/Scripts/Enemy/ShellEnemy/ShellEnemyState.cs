using NUnit.Framework.Internal.Filters;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShellEnemyState : EnemyBase
{
    [SerializeField] private Transform idlePoint; //待機ポイントの座標
    [SerializeField] private SightCheckerManager sightChecker;//視界クラス

    RaycastHit hit;

    //現在のステート
    private ICharactorState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, ICharactorState> states;

    protected override void Awake()
    {
        base.Awake();
        //ステートのインスタンス化
        states = new Dictionary<System.Type, ICharactorState>()
        {
            { typeof(ShellEnemyIdleState), new ShellEnemyIdleState(this)},
            { typeof(ShellEnemyChaseState), new ShellEnemyChaseState(this)},
            { typeof(ShellEnemyBackState), new ShellEnemyBackState(this)},
            { typeof(ShellEnemyAttackState), new ShellEnemyAttackState(this)},
        };

        //初期ステートの設定
        SwicthState(typeof(ShellEnemyIdleState));
    }

    // Update is called once per frame
    void Update()
    {
        //現在のステートのUpdateを呼び出す
        currentState?.Update();
    }

    public void SwicthState(System.Type newStateType)
    {
        //既存ステートがあればExitを呼び出す
        if (currentState != null)
        {
            currentState.Exit();
        }

        //新しいステートを取得
        if (states.TryGetValue(newStateType, out ICharactorState newState))
        {
            currentState = newState;
            Debug.Log(currentState);
            //新しいステートのEnterを呼び出す
            currentState.Enter();
        }
        else
        {
            //ステートが見つからなかったらエラー
            Debug.LogError($"State not found: {newStateType}");
        }
    }

    public void AnimaChange(string animationClip, bool isAnima)//ステートクラスでアニメーションを変える関数
    {
        animator.SetBool(animationClip, isAnima);
    }

    public Transform idlePointTransform { get { return idlePoint; } set {  idlePoint = value; }  }
    public SightCheckerManager sightCheckerManager { get { return sightChecker; } set { sightChecker = value; } }
}
