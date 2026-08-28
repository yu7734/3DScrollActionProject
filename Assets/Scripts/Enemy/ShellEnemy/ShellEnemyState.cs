using System.Collections.Generic;
using UnityEngine;

public class ShellEnemyState : EnemyBase
{
    [SerializeField] private Transform idlePoint;

    //現在のステート
    private ICharactorState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, ICharactorState> states;

    private void Awake()
    {
        //ステートのインスタンス化
        states = new Dictionary<System.Type, ICharactorState>()
        {
            { typeof(ShellEnemyIdleState), new ShellEnemyIdleState(this)},
            { typeof(ShellEnemyChaseState), new ShellEnemyChaseState(this)},
            { typeof(ShellEnemyBackState), new ShellEnemyBackState(this)},
            { typeof(ShellEnemyAttackState), new ShellEnemyAttackState(this)},
        };

        //初期ステートの設定
        SwicthState(typeof(NormalState));
    }

    // Update is called once per frame
    void Update()
    {
        //現在のステートのUpdateを呼び出す
        currentState?.Update();
        //Debug.Log(currentState);

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
        int layerMask = LayerMask.GetMask("Player");//床のレイヤーを取得する変数
        RaycastHit hit;
        Debug.DrawRay(transform.position, moveDirection * rayDistance, Color.red);// Sceneビューでデバッグ用にRayを可視化
        if (!Physics.Raycast(transform.position, moveDirection, out hit, rayDistance, layerMask)) return;
        if (hit.transform.tag == "Player")//Rayがプレイヤーにヒットしたら
            SwicthState(typeof(ShellEnemyAttackState));//攻撃ステートに切り替え
    }

    public Transform idlePointTransform { get; private set; }
}
