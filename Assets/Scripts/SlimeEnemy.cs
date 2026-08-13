using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rayDistance;
    private Rigidbody rigidbody;
    private Vector3 moveDirection;//敵の進行方向

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveDirection = Vector2.left;//最初は左向き
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMoveDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody.linearVelocity = new Vector3(moveSpeed * moveDirection.x, 0, 0);//向いている向きの方向に進む
    }

    private void ChangeMoveDirection()
    {
        Vector2 halfSize = transform.lossyScale / 2;//オブジェクトの2分１のサイズの変数
        int layerMask = LayerMask.GetMask("Floor");//床のレイヤーを取得する変数
        RaycastHit hit;
        Debug.DrawRay(transform.position, moveDirection * rayDistance, Color.red);// Sceneビューでデバッグ用にRayを可視化
        if (!Physics.Raycast(transform.position, moveDirection, out hit, rayDistance, layerMask)) return;
        if (hit.transform.tag == "Floor")
            moveDirection = -moveDirection;//壁があれば逆方向に向きを変える
    }
}
