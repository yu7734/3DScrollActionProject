using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Fall();
    }

    async UniTask Fall()
    {
        //1秒待ってから落下
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        if (rigidbody != null)
            rigidbody.isKinematic = false;

        //３秒経ったらオブジェクト削除
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        Destroy(this.gameObject);
    }
}
