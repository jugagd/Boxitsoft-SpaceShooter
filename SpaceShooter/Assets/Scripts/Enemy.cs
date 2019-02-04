using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {
    SpriteRenderer sR;
    // Use this for initialization
    void Start () {
        sR = GetComponentInChildren<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TakeDamage()
    {
        base.TakeDamage();
        life--;
        if (life>0)
        {
            sR.color = Color.red;
            Invoke("ReturnColor", 0.25f);
        }
        else
        {
            sR.color = Color.black;
        }
    }
    void ReturnColor()
    {
        sR.color = Color.white;
    }
}
