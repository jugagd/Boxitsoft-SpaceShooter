using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity {
    public Pool bulletPool;
    public override void testo()
    {
        InvokeRepeating("Shoot", 0, 5);
    }

    public override void Movement()
    {
        
        transform.Translate (0f,-speed*Input.GetAxis("Horizontal")*Time.deltaTime,0f);
    }
    void Shoot()
    {
        GameObject go = bulletPool.Get();
        go.transform.position = transform.position;
        //go.transform.rotation = transform.rotation;
    }
}
