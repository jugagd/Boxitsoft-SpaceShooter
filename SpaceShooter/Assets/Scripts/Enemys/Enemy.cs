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
    public int scoreValue;
    Color originalColor;
   public override void Start()

    {
        base.Start();
        transform.parent = GameObject.Find("EnemySpawner").transform;
        sR = GetComponentInChildren<SpriteRenderer>();
        originalColor = sR.color;
    }

    void ReturnColor()
    {
        sR.color = originalColor;
    }

    public override void TakeDamage()
    {
        if (life<0.5f)
            return;
        base.TakeDamage();
        if (life>=0.5f)
        {
            sR.color = Color.red;
            Invoke("ReturnColor", 0.25f);
        }
        else
        {
            LevelManager.s_Instance.actualScore += scoreValue;
            LevelManager.s_Instance.enemysAlive--;
            Die();
        }
    }
}
