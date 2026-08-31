using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected Rigidbody rb;
    [SerializeField] protected float rayDistance; //Ray‚Ì‹——£
    protected Vector3 moveDirection;//“G‚Ìis•ûŒü

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        moveDirection = Vector2.left;//Å‰‚Í¶Œü‚«
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        rb.linearVelocity = new Vector3(moveSpeed * moveDirection.x, 0, 0);//Œü‚¢‚Ä‚¢‚éŒü‚«‚Ì•ûŒü‚Éi‚Ş
    }

    public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
}
