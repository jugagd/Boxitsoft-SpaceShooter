using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : JumpingEnemy
{
    public override void Start()
    {
        base.Start();
        originalPosition = transform.position.x;
        Invoke("Jump", timeToAction);
    }
    public override void Action()
    {
        base.Action();
        timer += Time.deltaTime;
        if (timer >= timeToAction)
        {
            Shoot();
            timer = 0;
        }
    }

    public override void Shoot()
    {
        base.Shoot();
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.PlayerBullet = false;
    }
}
