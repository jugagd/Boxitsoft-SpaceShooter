using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSelectiveEnemy : ShootingEnemy{

    public override void Action()
    {
        base.Action();
        if (Mathf.Abs(LevelManager.s_Instance.playerRef.transform.position.x-transform.position.x)<1f)
            enemyBelow = true;
        else
            enemyBelow = false;
    }
}
