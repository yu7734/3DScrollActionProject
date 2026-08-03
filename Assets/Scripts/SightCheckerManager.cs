using UnityEngine;

public class SightCheckerManager : MonoBehaviour
{
    [SerializeField] private Transform _self;//自分自身
    [SerializeField] private Transform _target;//ターゲット(プレイヤー)
    [SerializeField] private float _sightAngle;//視野角
    [SerializeField] private float _maxDistance = float.PositiveInfinity;//視界の最大距離
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsRock()
    {
        var _selfPos = _self.position;//自身の位置
        var _targetPos = _target.position;//ターゲットの位置
        var _selfDir = _self.forward;//自身の向き
        var targetDirection = _targetPos - _selfPos;//ターゲットまでの向き
        var targetDistance = targetDirection.magnitude;//ターゲットまでの距離計算

        var cosHalf = Mathf.Cos(_sightAngle / 2 * Mathf.Deg2Rad);//cos(視野角 / 2)

        //自身とターゲットの内積
        var innerProduct = Vector3.Dot(_selfDir, targetDirection.normalized);

        return innerProduct > cosHalf && targetDistance < _maxDistance;//視界判定
    }

    // 視界判定の結果をGUI出力
    private void OnGUI()
    {
        // 視界判定
        var isVisible = IsRock();

        // 結果表示
        GUI.Box(new Rect(20, 20, 150, 23), $"isVisible = {isVisible}");
    }
}
