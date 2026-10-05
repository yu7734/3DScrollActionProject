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

    [SerializeField, Tooltip("ƒXƒ‰ƒCƒh‚·‚éŽžŠÔ")] private float slideTime;
    [SerializeField] private SlideMode slideMode;
    private RectTransform rectTransform;

    private bool isSlide;

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
        
    }

    private void SlidePanel()
    {
        if (!isSlide) return;

        switch (slideMode)
        {
            case SlideMode.Open: break;
            case SlideMode.Close: CloseSlide(); break;
        }
    }

    private void CloseSlide()
    {
        transform.DOMoveX(-728, slideTime);
        SceneManager.LoadScene("GameScene");
    }
}