using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float life;
    public float speed;
    Pool bulletPool;
    Pool explosionPool;
    public GameObject go;

    public virtual void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<Pool>();
        explosionPool = GameObject.Find("ExplosionPool").GetComponent<Pool>();
    }
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

    public void Die()
    {
        go = explosionPool.Get();
        go.transform.position = transform.position;
        go.transform.rotation = transform.rotation;
        Destroy(this.gameObject);
    }
}
