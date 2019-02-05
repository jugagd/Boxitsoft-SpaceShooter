using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float life;
    public float speed;
    public Pool bulletPool;
    public GameObject go;
   
    private void FixedUpdate()
    {
        Action();
    }

    public virtual void Action()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if ((gameObject.tag == "Player" && !bullet.PlayerBullet) ||
                (gameObject.tag == "Enemy" && bullet.PlayerBullet))
                TakeDamage();
        }
    }

    public virtual void Shoot()
    {
        go = bulletPool.Get();
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
    } 

    public virtual void TakeDamage()
    {
        life--;
    }
}
