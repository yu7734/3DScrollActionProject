using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    private SlidePanelManager slidePanelManager;

    private void Start()
    {
        SoundManager.Instance.PlayBGM(BGMSoundData.BGM.Title, true);
    }

    public void GameStart()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.PushBottom);
        slidePanelManager.StartSlide(LoadGame);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void GameQuit()
    {
        SoundManager.Instance.PlaySE(SESoundData.SE.PushBottom);
        Application.Quit();
    }
}
