using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    //現在のステート
    private IPlayerState currentState;

    //全てのステートを保持するディクショナリ
    Dictionary<System.Type, IPlayerState> states;

    //オブジェクト、クラスを参照
    private Animator animator;
    public Vector3 playerDirection = Vector3.zero;
    public CharacterController characterController;
    //プレイヤーモデルを取得
    public GameObject _playerObject;
    public PlayerInputScript _playerInput;
    public float playerMoveSpeed;
    public float playerJumpPower;
    //重力
    public float gravity = 20.0f;

    private bool isAttack;

    public Collider weaponCollider;

    private void Awake()
    {
        //_playerObject = GetComponentInChildren<GameObject>();
        //ステートのインスタンス化
        states = new Dictionary<System.Type, IPlayerState>()
        {
            {typeof(PlayerIdleState),   new PlayerIdleState(this) },
            {typeof(PlayerMoveState),   new PlayerMoveState(this) },
            {typeof(PlayerAttackState), new PlayerAttackState(this) },
            {typeof(PlayerJumpState),   new PlayerJumpState(this)  },
            {typeof(PlayerFallState),   new PlayerFallState(this)  },
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
        Debug.Log(currentState);
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

    //アニメーションの切り替えメソッド
    public void CAnima(string animaName, bool bAnima)
    {
        animator.SetBool(animaName, bAnima);
    }

    public void PlayerMove()
    {
        //入力に応じて移動
        var moveVelocity = new Vector3(_playerInput._inputMove.x * playerMoveSpeed, playerDirection.y, 0);

        //入力に応じて向きを変える
        if (_playerInput._inputMove.x < 0)
            _playerObject.transform.eulerAngles = new Vector3(0, -90, 0);
        else if (_playerInput._inputMove.x > 0)
            _playerObject.transform.eulerAngles = new Vector3(0, 90, 0);

        characterController.Move(moveVelocity * Time.deltaTime);
    }
}
