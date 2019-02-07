using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : Enemy {
    float playerPosition;
    public float originalPosition;
    float originalHeight;
    bool jumping;
    bool returning;
    float delta;
    public override void Start()
    {
        base.Start();
        originalPosition = transform.position.x;
        originalHeight = transform.position.y;
        InvokeRepeating("Jump", timeToAction,timeToRecalibrate);

    }
    public override void Action()
    {
        base.Action();
        if (jumping)
        {
            if (delta > speed)
                transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            else if (delta<-speed)
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
             transform.Translate(0f, speed * Time.deltaTime, 0f);
        }
        if (returning)
        {
            if (transform.position.y-originalHeight>=0)
                transform.Translate(0f, speed * Time.deltaTime, 0f);
            else
            {
                returning = false;
                InvokeRepeating("Jump", timeToAction, timeToRecalibrate);
            }
            
        }

    }

    void Jump()
    {
        GameObject player = LevelManager.s_Instance.playerRef; ;
        if (player!=null)
        {
            playerPosition = player.transform.position.x;            
            delta = playerPosition - transform.position.x;
            jumping = true;
        }
        
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);    
        if (collision.gameObject.name=="Bottom")
        {
            CancelInvoke("Jump");
            jumping = false;
            ReturnToScreen();
        }
    }

    void ReturnToScreen()
    {
        transform.position = new Vector3(originalPosition, originalHeight + 4*speed, 0f);
        returning = true;
    }

    
}
