using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    //現在のステート
    private IPlayerState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, IPlayerState> states;

    //オブジェクト、クラスを参照
    Rigidbody rb;
    private Animator animator;
    public CharacterController characterController;
    [SerializeField] public PlayerInputScript _playerInput;
    [SerializeField] public float playerMoveSpeed;

    private void Awake()
    {
        //ステートのインスタンス化
        states = new Dictionary<System.Type, IPlayerState>()
        {
            {typeof(PlayerIdleState),   new PlayerIdleState(this) },
            {typeof(PlayerMoveState),   new PlayerMoveState(this) },
            {typeof(PlayerAttackState), new PlayerAttackState(this) },
        };

        //初期ステートの設定
        SwicthState(typeof(PlayerIdleState));

        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
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

    //アニメーションの切り替えメソッド
    public void CAnima(string animaName, bool bAnima)
    {
        animator.SetBool(animaName, bAnima);
    }
}
