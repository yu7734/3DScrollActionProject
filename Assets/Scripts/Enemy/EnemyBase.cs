using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    protected Rigidbody rb;
    [SerializeField] protected float rayDistance; //Rayの距離
    [SerializeField] protected float rayHeight;//rayの発射する高さ
    protected bool isFloor;//床に着いているかいないか
    protected Vector3 moveDirection;//敵の進行方向
    protected Animator animator;
    public delegate void HitRay(); //Rayが当たった時の処理をするデリゲートを宣言
    public HitRay hitRay; //関数を変数に
    [SerializeField] protected ScoreManager scoreManager;

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

    public void EnemyRay(string hitObject, HitRay hitRay)　//rayが当たったときの処理
    {
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + new Vector3(0, rayHeight, 0); //発射位置をVectorに
        Debug.DrawRay(rayOrigin, MoveDirection * rayDistance, Color.red);
        if (!Physics.Raycast(rayOrigin, moveDirection, out hit, rayDistance)) return;
        if (!(hit.transform.tag == hitObject)) return;
        hitRay();
    }

    public void HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position + new Vector3(0, 0.5f, 0);
        Vector3 raySize = new Vector3(transform.lossyScale.x, 0.1f, 0.1f);
        RaycastHit hit;
        if (Physics.BoxCast(rayPos, Vector3.one * 0.5f, Vector3.down, out hit,
            Quaternion.identity, 0.1f, layerMask))
        {
             isFloor = true;
        }
        else isFloor = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(0, 0.4f, 0), Vector3.one);
    }

    public Vector3 MoveDirection { get { return moveDirection; } set { moveDirection = value; } }
}
