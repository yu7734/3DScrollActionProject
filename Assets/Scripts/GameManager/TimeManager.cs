using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private PlayerDamageStateMachine playerDamage;
    [SerializeField, Header("制限時間")] private float maxTime;
    [SerializeField] private TextMeshProUGUI timeText;
    private float time;
    
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
        time -= Time.deltaTime;
        if (time >= 0) return;
        playerDamage.PlayerHP = 0;
        playerDamage.SwicthState(typeof(DeadState));
    }

    private void TimeText()
    {
        timeText.text = time.ToString("F1");
    }
}
