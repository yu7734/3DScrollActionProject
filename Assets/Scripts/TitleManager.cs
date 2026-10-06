using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private SlidePanelManager slidePanelManager;

    public void GameStart()
    {
        slidePanelManager.StartSlide(LoadGame);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
