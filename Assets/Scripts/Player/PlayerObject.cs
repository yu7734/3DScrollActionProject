using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //アニメーションの切り替えメソッド
    public void CAnima(string animaName, bool bAnima)
    {
        animator.SetBool(animaName, bAnima);
    }
}
