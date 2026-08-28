using System.Collections.Generic;
using UnityEngine;

public class ShellEnemyState : EnemyBase
{
    //現在のステート
    private ICharactorState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, ICharactorState> states;

    [SerializeField] private int playerHP;
    private Renderer[] renderers;
    private CharacterController characterController;

    private void Awake()
    {
        //ステートのインスタンス化
        states = new Dictionary<System.Type, ICharactorState>()
        {
            { typeof(ShellEnemyIdleState), new ShellEnemyIdleState(this)},
            { typeof(ShellEnemyChaseState), new ShellEnemyIdleState(this)},
        };

        renderers = GetComponentsInChildren<Renderer>();//子オブジェクトのレンダーを取得
        characterController = GetComponentInChildren<CharacterController>();

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
}
