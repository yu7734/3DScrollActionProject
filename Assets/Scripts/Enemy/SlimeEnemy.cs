using UnityEngine;

public class SlimeEnemy : EnemyBase
{
    // Update is called once per frame
    void Update()
    {
        EnemyRay("Floor", ChangeMoveDirection);
        HitFloor();
    }

    private void FixedUpdate()
    {
        Debug.Log($"isFloor: {isFloor}, direction: {moveDirection}");
        if (isFloor)
        {
            animator.SetBool("isFloor", true);
            Move();
        }
        else
        {
            animator.SetBool("isFloor", false);
        }
    }

    private void OnDisable()
    {
        scoreManager.IncreaseScore(100);
    }

    private void ChangeMoveDirection()
    {
            moveDirection = -moveDirection;//•Ç‚ª‚ ‚ê‚Î‹t•ûŒü‚ÉŒü‚«‚ð•Ï‚¦‚é
    }
}
