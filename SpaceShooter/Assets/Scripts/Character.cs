using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    bool immortal = false;
    public override void Action()
    {
        transform.Translate (speed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        
    }

    public override void TakeDamage()
    {
        if (life<0.5f)
            return;
        base.TakeDamage();
        if (life<0.5f)
            Die();
    }

    private void Update()
    {
        if (Time.timeScale>0)
            if (Input.GetButtonDown("Fire"))
                Shoot();
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!immortal)
            {
                life = int.MaxValue;
                immortal = true;
            }
            else
            {
                life = 1.3f;
                immortal = false;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            TakeDamage();
        }
    }
}
