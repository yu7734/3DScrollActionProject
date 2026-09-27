using System;
using UnityEngine;

public class FallDieZone : MonoBehaviour
{
    [SerializeField] private PlayerDamageStateMachine playerDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //触れたらHPを０にして、死亡ステートに変更し、ゲームオーバー
        if (!other.CompareTag("Player")) return;
        playerDamage.PlayerHP = 0;
        playerDamage.SwicthState(typeof(DeadState));
    }
}
