using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    SpriteRenderer sR;
    public float timeToAction;
    public float timer;
    void Start ()
    {
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
            sR.color = Color.black;
        }
    }

   
}
