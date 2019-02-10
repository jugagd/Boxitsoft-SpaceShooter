using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
    //Immortal "cheat" for testing.
    private bool _immortal = false;

    public override void Action()
    {
        //Player movement based on input.
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
        //Shooting input.
        if (Time.timeScale>0)
            if (Input.GetButtonDown("Fire"))
                Shoot();
        //Immortal "cheat".
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!_immortal)
            {
                life = int.MaxValue;
                _immortal = true;
            }
            else
            {
                life = 1.3f;
                _immortal = false;
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
            TakeDamage();
    }
}
