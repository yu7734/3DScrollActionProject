using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField, Header("HPアイコン")] private GameObject HPIcon;
    [SerializeField] private PlayerDamageStateMachine player;
    private int beforeHP;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        beforeHP = player.PlayerHP;
        CreateHP();
    }

    // Update is called once per frame
    void Update()
    {
        ShowHPIcon();
    }

    private void CreateHP()
    {
        for (int i = 0; i < player.PlayerHP; ++i)
        {
            GameObject playerHPObject = Instantiate(HPIcon);//HPアイコン生成
            playerHPObject.transform.parent = transform;//位置を親オブジェクトの位置に
        }
    }

    private void ShowHPIcon()
    {
        //HPが減ったら、
        if (beforeHP == player.PlayerHP) return;

        Image[] icons = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < icons.Length; ++i)
        {
            icons[i].gameObject.SetActive(i < player.PlayerHP);
        }

        beforeHP = player.PlayerHP;
    }
}
