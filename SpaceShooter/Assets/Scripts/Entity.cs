using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float life;
    public float speed;

	// Use this for initialization
	void Start () {
        testo();
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();
    }
    void Update () {
	
	}

    public virtual void Movement()
    {

    }

    public virtual void testo()
    {
        Debug.Log("Sarasa");
    }
}
