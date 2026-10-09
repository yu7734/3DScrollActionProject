using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private SlidePanelManager slidePanelManager;
    [SerializeField] private GameObject player;
    private bool isGameOver;
    private bool isGameClear;
    private bool isGameStart;

    private void Awake()
    {
        player.GetComponent<PlayerInputScript>().enabled = false;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        gameClearUI.SetActive(false);
        player.GetComponent<PlayerInputScript>().enabled = false;//操作不可
        slidePanelManager.StartSlide(GameStart);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        GameClear();
    }

    private void GameOver()
    {
        if (!isGameOver) return;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    private void GameClear()
    {
        if (!isGameClear) return;
        gameClearUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetryBottom()
    {
        slidePanelManager.StartSlide(ReLoadGame);//パネルをスライドさせてからロード
    }

    private void ReLoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GameStart()
    {
        //プレイヤーが操作可能に
        player.GetComponent<PlayerInputScript>().enabled = true;
        isGameStart = true;
    }

    public bool GetSetIsGameOver { get { return isGameOver; } set { isGameOver = value; } }
    public bool GetSetIsGameClear { get { return isGameClear; } set { isGameClear = value; } }
    public bool GetSetIsGameStart { get { return isGameStart; } set { isGameStart = value; } }
}
