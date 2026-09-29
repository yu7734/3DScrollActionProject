using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TimeManager timeManager;
    private GameObject flagObject;

    private void Awake()
    {
        flagObject = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーに触れたらゴール
        if (!other.CompareTag("Player")) return;
        Goal();
    }

    private void Goal()
    {
        Debug.Log("Goal");
        flagObject.SetActive(false);
        timeManager.AddRemainingTimeToScore();//残り時間をスコアに追加
        gameManager.GetSetIsGameClear = true;
    }
}
