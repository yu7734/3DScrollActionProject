using UnityEngine;

public class SlimeEnemy : EnemyBase
{
    // Update is called once per frame
    void Update()
    {
        EnemyRay("Floor", ChangeMoveDirection);
    }

    private void FixedUpdate()
    {
        Move();
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
