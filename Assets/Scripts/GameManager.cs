using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;
    private bool isGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (!isGameOver) return;
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void RetryBottom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool GetSetIsGameOver { get { return isGameOver; } set { isGameOver = value; } }
}
