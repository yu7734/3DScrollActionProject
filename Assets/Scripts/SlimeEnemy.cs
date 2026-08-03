using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody.linearVelocity = new Vector3(-moveSpeed, 0, 0);
    }
}
