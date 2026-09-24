using UnityEngine;

public class ReSpornFallFloor : MonoBehaviour
{
    [SerializeField] private GameObject fallFloor;
    private float reSpornTime;
    private bool isDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.gameObject.transform.position = fallFloor.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ReSporn();
    }

    private void ReSporn()
    {
        //落ちる床が消えたらカウント開始
        if (!isDestroy) return;
        reSpornTime += Time.deltaTime;

        //カウントが経ったらリスポーン
        if (reSpornTime < 3) return;
        fallFloor.transform.position = this.gameObject.transform.position;
        fallFloor.SetActive(true);
        reSpornTime = 0;
        isDestroy = false;
    }

    public bool GetIsDestroy {  get { return isDestroy; } set { isDestroy = value; } }
}
