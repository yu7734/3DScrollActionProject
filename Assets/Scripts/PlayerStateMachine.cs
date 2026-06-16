using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    //現在のステート
    private IPlayerState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, IPlayerState> states;

    private void Awake()
    {
        //ステートのインスタンス化
        states = new Dictionary<System.Type, IPlayerState>()
        {
            {typeof(PlayerIdleState), new PlayerIdleState(this) },
            {typeof(PlayerMoveState), new PlayerMoveState(this) },
        };

        //初期ステートの設定
        SwicthState(typeof(PlayerStateMachine));
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
        if (states.TryGetValue(newStateType, out IPlayerState newState))
        {
            currentState = newState;
            //新しいステートのEnterを呼び出す
            currentState.Enter();
        }
        else
        {
            Debug.LogError($"State not found: {newStateType}");
        }
    }
}
