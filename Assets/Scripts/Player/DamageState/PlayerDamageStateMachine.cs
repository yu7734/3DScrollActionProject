using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageStateMachine : MonoBehaviour
{
    //現在のステート
    private IPlayerState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, IPlayerState> states;
    private void Awake()
    {
        //_playerObject = GetComponentInChildren<GameObject>();
        //ステートのインスタンス化
        states = new Dictionary<System.Type, IPlayerState>()
        {
            
        };

        //初期ステートの設定
        SwicthState(typeof(PlayerIdleState));
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
            //ステートが見つからなかったらエラー
            Debug.LogError($"State not found: {newStateType}");
        }
    }
}
