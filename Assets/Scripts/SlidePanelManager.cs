using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class SlidePanelManager : MonoBehaviour
{
    public enum SlideMode
    {
        Open,
        Close
    }

    [SerializeField, Tooltip("スライドする時間")] 
    private float slideTime;
    [SerializeField, Tooltip("最初のスライドのモード")] 
    private SlideMode slideMode;

    private Tween slideTween;

    private RectTransform rectTransform;

    //スライド終了後のデリゲート宣言
    public delegate void SlideComplete();
    public SlideComplete slideComplete;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private async UniTask CloseSlide()
    {
        this.rectTransform.anchoredPosition = new Vector3(800, 0, 0);
        //リトライボタン押した時にスライドアニメーションを動かすためにSetUpdateを付け足し
        slideTween = rectTransform.DOAnchorPosX(0, slideTime).SetUpdate(true);
        await slideTween.AsyncWaitForCompletion();
        CompleteSlide();
    }
    private async UniTask OpenSlide()
    {
        slideTween = rectTransform.DOAnchorPosX(-800, slideTime);
        await slideTween .AsyncWaitForCompletion();
        CompleteSlide();
    }

    private void CompleteSlide()
    {
        //スライド終了後、モード切替、デリゲート実行
        slideMode = slideMode == SlideMode.Open ? SlideMode.Close : SlideMode.Open;
        slideComplete.Invoke();
    }

    public void StartSlide(SlideComplete listener)
    {
        //デリゲートに関数を登録して、実行
        slideComplete = listener;

        switch (slideMode)
        {
            case SlideMode.Open: OpenSlide(); break;
            case SlideMode.Close: CloseSlide(); break;
        }
    }
}