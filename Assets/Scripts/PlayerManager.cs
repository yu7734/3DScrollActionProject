using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody rb;
    private Animator animator;
    private CharacterController characterController;
    [SerializeField] private PlayerInputScript _playerInput;
    [SerializeField] private float playerMoveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //ÉvÉåÉCÉÑÅ[ÇÃà⁄ìÆ
    private void PlayerMove()
    {
        var moveVelocity = new Vector3(_playerInput._inputMove.x * playerMoveSpeed * Time.deltaTime, 0, 0);
        characterController.Move(moveVelocity);
    }
}
