using System;
using UnityEngine;

/// <summary>
/// isGroundでは着地判定が上手く出来ないためRayCastを使用して着地判定をする
/// </summary>
public class RaycastCheckGround : MonoBehaviour
{
    [SerializeField] private float _rayLength = 1.0f;        //rayの長さ
    [SerializeField] private float _rayOffset = 0.0f;        //rayをどのくらいに体をめり込ませるか
    [SerializeField] private LayerMask _layerMask = default; //ray判定を用いるLayer

    private CharacterController characterController;
    private bool _isGround;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        _isGround = CheckGround();
    }

    private bool CheckGround()
    {
        //放つ光線と初期位置と姿勢
        var ray = new Ray(origin: transform.position + Vector3.up * _rayOffset, direction: Vector3.down);

        //Raycastがhitするかどうかで判定
        return Physics.Raycast(ray, _rayLength, _layerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _isGround ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position + Vector3.up * _rayOffset, Vector3.down * _rayLength);
    }

    public bool GetIsGround { get { return _isGround; } }
}
