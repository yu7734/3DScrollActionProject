using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageStateMachine : MonoBehaviour
{
    //現在のステート
    private IPlayerState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, IPlayerState> states;

    [SerializeField] private int playerHP;
    private Renderer renderers;
    private CharacterController characterController;

    private void Awake()
    {
        //ステートのインスタンス化
        states = new Dictionary<System.Type, IPlayerState>()
        {
            {typeof(NormalState), new NormalState(this) },
            {typeof(DamagedState), new DamagedState(this) },
        };

        renderers = GetComponentInChildren<Renderer>();//子オブジェクトのレンダーを取得
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

    private void OnControllerColliderHit(ControllerColliderHit hit)//当たり判定
    {
        currentState.OnControllerColliderHit(hit);
    }

    public int PlayerHP { get { return playerHP; } set { playerHP = Mathf.Max(0, value); } }//プレイヤーの体力のプロパティ
    public Renderer renderer {  get { return renderers; }  set { renderers = value; } }//レンダーのプロパティ
    public CharacterController CharacterController { get { return characterController; } }//キャラクターコントローラーのプロパティ
}
