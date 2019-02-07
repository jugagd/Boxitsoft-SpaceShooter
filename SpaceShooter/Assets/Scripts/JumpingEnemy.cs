using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : Enemy {
    float playerPosition;
    float originalPosition;
    float speedX;
    bool jumping;
    float delta;
    public override void Start()
    {
        base.Start();

        speedX = speed;
        originalPosition = transform.position.x;
        Invoke("Jump", timeToAction);

    }
    public override void Action()
    {
        base.Action();
        if (jumping)
        {
            if (delta > 1)
            {
                transform.Translate(-speed * Time.deltaTime, 0f, 0f);
                delta = playerPosition - transform.position.x;
            }
            else if (delta<-1)
            {
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
                delta = playerPosition - transform.position.x;
            }
            transform.Translate(0f, speed * Time.deltaTime, 0f);
        }

    }

    void Jump()
    {
        playerPosition = LevelManager.s_Instance.playerRef.transform.position.x;
        jumping = true;
        delta = playerPosition - originalPosition;
    }
    
}
