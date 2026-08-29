using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShellEnemyState : EnemyBase
{
    [SerializeField] private Transform idlePoint;
    [SerializeField] public SightCheckerManager sightChecker;

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

    public void AttackRay()
    {
        Vector2 halfSize = transform.lossyScale / 2;//オブジェクトの2分１のサイズの変数
        int layerMask = LayerMask.GetMask("Player");//プレイヤーのレイヤーを取得する変数
        RaycastHit hit;
        Debug.DrawRay(transform.position, moveDirection * rayDistance, Color.red);// Scene?r???[??f?o?b?O?p??Ray???????
        if (!Physics.Raycast(transform.position, moveDirection, out hit, rayDistance, layerMask)) return;
        if (hit.transform.tag == "Player")//Rayがプレイヤーにヒットしたら
            SwicthState(typeof(ShellEnemyAttackState));//攻撃ステートに変更
    }

    public Transform idlePointTransform { get; private set; }
    public SightCheckerManager sightCheckerManager { get { return sightCheckerManager; } set { sightCheckerManager = value; } }
}
