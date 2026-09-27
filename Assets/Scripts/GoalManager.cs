using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private GameObject flagObject;

    private void Awake()
    {
        flagObject = transform.GetChild(0).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーに触れたらゴール
        if (!other.CompareTag("Player")) return;
        Goal();
    }

    private void Goal()
    {
        Debug.Log("Goal");
        flagObject.SetActive(false);
        gameManager.GetSetIsGameClear = true;
    }
}
