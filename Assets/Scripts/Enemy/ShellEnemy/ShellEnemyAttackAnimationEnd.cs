using System;
using UnityEngine;

public class ShellEnemyAttackAnimationEnd : MonoBehaviour
{
    [SerializeField] private ShellEnemyState _state;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnd()
    {
        _state.SwicthState(typeof(ShellEnemyChaseState));
    }
}
