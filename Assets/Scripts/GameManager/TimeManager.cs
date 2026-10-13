using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private PlayerDamageStateMachine playerDamage;
    [SerializeField, Header("制限時間")] private float maxTime;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private ScoreManager scoreManager;
    private GameManager gameManager;
    private float time;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        LimitedTime();
        TimeText();
    }

    private void LimitedTime()
    {
        //制限時間が0になったらプレイヤー死亡（ゲームオーバー）
        if (!gameManager.GetSetIsGameStart) return;
        time -= Mathf.Max(0, Time.deltaTime);
        if (time >= 0) return;
        playerDamage.PlayerHP = 0;
        playerDamage.SwicthState(typeof(DeadState));
    }

    private void TimeText()
    {
        timeText.text = time.ToString("F1");
    }

    public void AddRemainingTimeToScore()
    {
        //残り時間×10でスコア追加
        int timeScore = (int)time * 10;
        scoreManager.IncreaseScore(timeScore);
    }
}
