using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{   
    public override void Action()
    {
        transform.Translate (speed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, 0f);
        
    }

    public override void Shoot()
    {
        base.Shoot();   
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.PlayerBullet = true;
    }

    public override void TakeDamage()
    {
        base.TakeDamage();
        if (life<=0)
            Die();
    }

    private void Update()
    {        
        if (Input.GetButtonDown("Fire"))
            Shoot();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {
            TakeDamage();
        }
    }
}
