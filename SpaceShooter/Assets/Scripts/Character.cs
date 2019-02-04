using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity
{
   
    public override void Movement()
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
    }

    private void Update()
    {        
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }
}
