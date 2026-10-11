using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField, Header("éãç∑å¯â "), Range(0, 1)]
    private float prallaxEffect;

    [SerializeField] private GameObject camera;
    private float length;
    private float startPosX;
    private float startPosY;

    private void Awake()
    {
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Prallax();
    }

    private void Prallax()
    {
        float temp = camera.transform.position.x * (1 - prallaxEffect);
        float dist = camera.transform.position.x * prallaxEffect;//äeâÊëúÇÃà íuÇè≠ÇµÇ∏Ç¬ÉYÉâÇ∑

        transform.position = new Vector3(startPosX + dist, (startPosY - 1) + camera.transform.position.y, transform.position.z);

        if (temp > startPosX + length)
        {
            startPosX += length;
        }
        else if (temp < startPosX - length)
        {
            startPosX -= length;
        }
    }
}
