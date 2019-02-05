using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy {

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
