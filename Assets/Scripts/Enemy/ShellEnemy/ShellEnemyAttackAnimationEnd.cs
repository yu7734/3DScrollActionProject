using System;
using UnityEngine;

public class ShellEnemyAttackAnimationEnd : MonoBehaviour
{
    [SerializeField] private ShellEnemyState _state;

    public void AttackEnd()
    {
        _state.SwicthState(typeof(ShellEnemyChaseState));
    }
}
