using System;
using UnityEngine;

public class FallGround : MonoBehaviour
{
    [SerializeField] private PlayerMovementStateMachine player;
    [SerializeField] private float fallSpeed;
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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
            rigidbody.useGravity = true;
    }
}
