using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected Rigidbody rigidbody;
    protected Vector3 moveDirection;//“G‚Ìis•ûŒü
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        rigidbody.linearVelocity = new Vector3(moveSpeed * moveDirection.x, 0, 0);//Œü‚¢‚Ä‚¢‚éŒü‚«‚Ì•ûŒü‚Éi‚Ş
    }
}
