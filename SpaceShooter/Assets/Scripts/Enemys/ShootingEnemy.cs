using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public bool enemyBelow=true;
    public override void Action()
    {
        base.Action();
        timer += Time.deltaTime;
        if ((timer >= timeToAction)&&enemyBelow)
        {
            Shoot();
            timer = 0;
        }
    }
}
