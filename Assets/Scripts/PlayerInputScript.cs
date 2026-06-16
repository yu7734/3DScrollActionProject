using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputScript: MonoBehaviour
{
    private InputSystem_Actions inputActions;
    [SerializeField] private PlayerManager _playerManager;
    [SerializeField] private PlayerObject _playerObject;
    //ステートマシンスクリプト
    [SerializeField] private PlayerStateMachine _playerStateMachine;
    public Vector2 _inputMove = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //インスタンス生成
        inputActions = new InputSystem_Actions();

        //イベントの明示的な登録
        //移動イベントの登録
        inputActions.Player.Move.started += OnMove;
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;

        //攻撃イベントの登録
        inputActions.Player.Attack.performed += OnAttack;
        inputActions.Player.Attack.canceled += OnAttack;

        //InputSystemの有効化
        inputActions.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //生成したインスタンスの解放
    private void OnDisable()
    {
        inputActions?.Disable();
    }

    //移動イベント
    private void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerObject.CAnima("Walk", true);
        }

        if (context.performed)
        {
            _inputMove = context.ReadValue<Vector2>();
        }

        if (context.canceled)
        {
            _inputMove = Vector2.zero;
            _playerObject.CAnima("Walk", false);
        }
    }

    //攻撃イベント
    private void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }

        if (context.performed)
        {
            _playerStateMachine.SwicthState(typeof(PlayerAttackState));
        }

        if (context.canceled)
        {
            _playerStateMachine.SwicthState(typeof(PlayerIdleState));
        }
    }
}
