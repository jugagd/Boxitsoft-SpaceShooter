using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSelectiveEnemy : JumpingEnemy {

    public override void Action()
    {
        base.Action();
        if (LevelManager.s_Instance.playerRef!=null)
            if (Mathf.Abs(LevelManager.s_Instance.playerRef.transform.position.x - transform.position.x) < 1f)
                enemyBelow = true;
            else
                enemyBelow = false;
        if (jumping&&LevelManager.s_Instance.playerRef!=null)
        {
            delta = LevelManager.s_Instance.playerRef.transform.position.x - transform.position.x;
            if (delta > speed)
                transform.Translate(-speed * 2*Time.deltaTime, 0f, 0f);
            else if (delta<-speed)
                transform.Translate(speed * 2*Time.deltaTime, 0f, 0f);
        }
    }
}
