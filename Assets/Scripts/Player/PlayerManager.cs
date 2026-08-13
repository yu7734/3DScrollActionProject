using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int playerHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag != "Enemy") return;
        playerHP--;
        Debug.Log(playerHP);
    }
}
