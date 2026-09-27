using UnityEngine;

public class GoalManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーに触れたらゴール
        if (!other.CompareTag("Player")) return;
        Goal();
    }

    private void Goal()
    {
        Debug.Log("Goal");
        gameManager.GetSetIsGameClear = true;
    }
}
