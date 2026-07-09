using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーのオブジェクトを保持")] private Transform player;
    [SerializeField] private float cameraSmooth;
    //プレイヤーとカメラの位置
    private Vector3 offset;
    [SerializeField, Tooltip("カメラのZ座標")] private float cameraOffset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 desirePosition = player.transform.position + offset;
        desirePosition.z = cameraOffset;
        transform.position = desirePosition;
    }
}
