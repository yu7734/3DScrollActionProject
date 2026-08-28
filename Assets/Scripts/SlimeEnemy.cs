using UnityEngine;

public class SlimeEnemy : EnemyBase
{
    [SerializeField] private EnemyBase enemyBase;
    [SerializeField] private float rayDistance;

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
        enemyBase.Move();
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
