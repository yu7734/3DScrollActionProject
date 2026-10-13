using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private SlidePanelManager slidePanelManager;
    private bool isStart;

    private void Start()
    {
        Time.timeScale = 1;
        StartTitle();
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title, true);
    }


    //タイトルにロードした時にパネルをスライド
    private void StartTitle()
    {
        slidePanelManager.StartSlide(SlideTitle);
    }

    private void SlideTitle()
    {
        isStart = true;
    }

    public void GameStart()
    {
        if (!isStart) return;
        SoundManager.Instance.PlaySE(SESoundData.SE.PushBottom);
        slidePanelManager.StartSlide(LoadGame);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameQuit()
    {
        if (!isStart) return;
        SoundManager.Instance.PlaySE(SESoundData.SE.PushBottom);
        Application.Quit();
    }
}
