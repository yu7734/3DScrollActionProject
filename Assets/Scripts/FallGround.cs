using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    private bool isFall;
    [SerializeField] private ReSpornFallFloor reSpornFallFloor;
    Rigidbody rigidbody;
    private Renderer renderer;
    private Color startColor;


    //床が移動した距離
    public Vector3 DeltaPosition { get; private set; }
    private Vector3 PreviousPosition;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PreviousPosition = transform.position;
        startColor = renderer.material.color;　//最初の色を取得
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall)
            transform.Translate(new Vector3(0, -fallSpeed, 0) * Time.deltaTime);

        //床の移動量を取得
        DeltaPosition = transform.position - PreviousPosition;
        PreviousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Fall();
    }

    async UniTask Fall()
    {
        //色を赤色に変更して1秒待ってから落下
        renderer.material.color = Color.red;
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        isFall = true;

        //３秒経ったら色を戻しオブジェクト削除
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        isFall = false;
        reSpornFallFloor.GetIsDestroy = true;
        renderer.material.color = startColor;
        this.gameObject.SetActive(false);
    }

    public float GetFallSpeed { get { return fallSpeed; } }
}
