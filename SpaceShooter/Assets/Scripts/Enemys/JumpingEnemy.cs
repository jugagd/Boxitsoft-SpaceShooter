using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : ShootingEnemy {
    float playerPosition;
    public float originalPosition;
    float originalHeight;
    public bool jumping;
    bool returning;
    public float delta;
    public Spawner spawnerRef;

    public override void Start()
    {
        base.Start();
        
        originalPosition = transform.localPosition.x;
        originalHeight = transform.localPosition.y;
        //InvokeRepeating("Jump", timeToAction,timeToRecalibrate);
        Invoke("Jump", timeToAction);
        spawnerRef = GameObject.Find("EnemySpawner").GetComponent<Spawner>();
        speed = spawnerRef.speed;

    }
    public override void Action()
    {
        
        base.Action();
        if (jumping)
        {
             transform.Translate(-speed*spawnerRef.direction*Time.deltaTime, speed * Time.deltaTime, 0f);
        }
        if (returning)
        {
            if (transform.localPosition.y-originalHeight<=0)
                transform.Translate(0f, speed * Time.deltaTime, 0f);
            else
            {
                returning = false;
                //InvokeRepeating("Jump", timeToAction, timeToRecalibrate);
                Invoke("Jump", timeToAction);
            }
        }

    }

    void Jump()
    {
        GameObject player = LevelManager.s_Instance.playerRef;
        if (player!=null)
        {/*
            playerPosition = player.transform.position.x;            
            delta = playerPosition - transform.position.x;*/
            jumping = true;
        }
        
    }
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);    
        if (collision.gameObject.name=="Bottom")
        {
            //CancelInvoke("Jump");
            jumping = false;
            ReturnToScreen();
        }
    }

    void ReturnToScreen()
    {
        transform.localPosition = new Vector3(originalPosition, originalHeight -4*speed, 0f);
        returning = true;
    }

    
}
