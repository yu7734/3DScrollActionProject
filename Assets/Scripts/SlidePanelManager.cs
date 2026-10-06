using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SlidePanelManager : MonoBehaviour
{
    public enum SlideMode
    {
        Open,
        Close
    }

    [SerializeField, Tooltip("スライドする時間")] 
    private float slideTime;
    private float slideCount;
    [SerializeField] 
    private SlideMode slideMode;

    private bool isSlide;

    private RectTransform rectTransform;

    public delegate void SlideComplete();
    public SlideComplete slideComplete;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SlidePanel();
    }

    private void SlidePanel()
    {
        if (!isSlide) return;

        switch (slideMode)//モードに応じてスライド処理を変える
        {
            case SlideMode.Open: OpenSlide(); break;
            case SlideMode.Close: CloseSlide(); break;
        }
    }

    private void CloseSlide()
    {
        //this.transform.position = new Vector3(730, 0, 0);
        slideCount += Time.deltaTime;
        rectTransform.DOAnchorPosX(-2, slideTime);

        //カウントが過ぎたら、デリゲート実行
        if (slideCount > slideTime + 0.5f)
        {
            slideMode = SlideMode.Open;
            isSlide = false;
            slideCount = 0;
            slideComplete.Invoke();
        }
    }

    private void OpenSlide()
    {
        //カウントを数え、Dotweenでスライド
        slideCount += Time.deltaTime;
        rectTransform.DOAnchorPosX(-802, slideTime);

        //カウントが過ぎたら、デリゲート実行
        if (slideCount > slideTime + 0.5f)
        {
            slideMode = SlideMode.Close;
            isSlide = true;
            slideCount = 0;
            slideComplete.Invoke();
        }
    }

    public void StartSlide(SlideComplete listener)
    {
        //デリゲートに関数を登録して、実行
        if (isSlide) return;
        isSlide = true;
        slideComplete = listener;
    }
}