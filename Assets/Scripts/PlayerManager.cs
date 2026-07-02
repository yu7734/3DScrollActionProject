using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //ƒvƒŒƒCƒ„[‚ÌˆÚ“®
    private void PlayerMove()
    {
        
    }
}
