using System;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private float spawnDistance;

    private bool[] isSpawned; //スポーン済みかの変数

    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpawned = new bool[enemy.Length];//要素数を敵オブジェクトと同じ数を取得

        for (int i = 0; i < enemy.Length; ++i)
        {
            enemy[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (isSpawned[i]) continue; //スポーン済みなら飛ばす

            float distance = enemy[i].transform.position.x - player.position.x;
            if (distance < spawnDistance) //スポーン距離以内なら出現
            {
                enemy[i].SetActive(true);
                isSpawned[i] = true;
            }
            
        }
    }
}
