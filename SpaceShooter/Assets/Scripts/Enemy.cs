using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    SpriteRenderer sR;
    public float timeToAction;
    public float timeToRecalibrate;
    public float timer;
    public float difficulty;

   public override void Start()

    {
        base.Start();
        transform.parent = GameObject.Find("EnemySpawner").transform;
        sR = GetComponentInChildren<SpriteRenderer>();
    }

    void ReturnColor()
    {
        sR.color = Color.white;
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
        if (life>0)
        {
            sR.color = Color.red;
            Invoke("ReturnColor", 0.25f);
        }
        else
        {
            LevelManager.s_Instance.actualScore += 10;
            LevelManager.s_Instance.enemysAlive--;
            Die();
        }
    }
}
