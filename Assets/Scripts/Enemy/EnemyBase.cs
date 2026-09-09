using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected Rigidbody rb;
    [SerializeField] protected float rayDistance; //Rayの距離
    protected Vector3 moveDirection;//敵の進行方向
    protected Animator animator;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        moveDirection = Vector3.left;//最初は左向き
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        rb.linearVelocity = new Vector3(moveSpeed * moveDirection.x, 0, 0);//向いている向きの方向に進む
        if (moveDirection.x < 0)//左向きならモデルを左に向ける
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else//右向きならモデルを右に向ける
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }

    public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
}
