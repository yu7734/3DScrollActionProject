using UnityEngine;

public class PlayerStartManager : MonoBehaviour
{
    [SerializeField] private bool isStart;
    [SerializeField] private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isStart)
            player.position = this.transform.position;
    }

    public bool GetSetIsStart {  get { return isStart; }  set { isStart = value; } }
}
