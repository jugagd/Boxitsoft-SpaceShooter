using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
    public float life;
    public float speed;
    Pool bulletPool;
    Pool explosionPool;

    public virtual void Start()
    {
        bulletPool = GameObject.Find("BulletPool").GetComponent<Pool>();
        explosionPool = GameObject.Find("ExplosionPool").GetComponent<Pool>();
        life = life * LevelManager.s_Instance.levelNumber;
    }
    private void FixedUpdate()
    {
        Action();
    }

    public virtual void Action()
    {
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if ((gameObject.tag == "Player" && !bullet.PlayerBullet) ||
                (gameObject.tag == "Enemy" && bullet.PlayerBullet))
                TakeDamage();
        }

        if ((collision.gameObject.tag=="Enemy"&&gameObject.tag=="Player")||
            (collision.gameObject.tag=="Player"&&gameObject.tag=="Enemy"))
        {
            TakeDamage();
        }
    }

    public virtual void Shoot()
    {
        GameObject bulletGO;
        bulletGO = bulletPool.Get();
        bulletGO.transform.position = transform.position;
        bulletGO.transform.rotation = transform.rotation;
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (this.gameObject.tag == "Player")
            bullet.PlayerBullet = true;
        else
            bullet.PlayerBullet = false;
        //Destroy(bulletGO);
    } 

    public virtual void TakeDamage()
    {
        life--;
    }

    public void Die()
    {
        GameObject explosionGO;
        explosionGO = explosionPool.Get();
        explosionGO.transform.position = transform.position;
        explosionGO.transform.rotation = transform.rotation;
        Destroy(this.gameObject);
    }
}
