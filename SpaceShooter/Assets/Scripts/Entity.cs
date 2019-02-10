using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Entity parameters")]
    public float life;
    public float speed;

    Pool _bulletPool;
    Pool _explosionPool;

    public virtual void Start()
    {
        _bulletPool = GameObject.Find("BulletPool").GetComponent<Pool>();
        _explosionPool = GameObject.Find("ExplosionPool").GetComponent<Pool>();
        
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
        //Hitted by bullet.
        if (collision.gameObject.tag == "Bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            if ((gameObject.tag == "Player" && !bullet.PlayerBullet) ||
                (gameObject.tag == "Enemy" && bullet.PlayerBullet))
                TakeDamage();
        }
        //Hitted by another entity (Of different team).
        if ((collision.gameObject.tag=="Enemy"&&gameObject.tag=="Player")||
            (collision.gameObject.tag=="Player"&&gameObject.tag=="Enemy"))
            TakeDamage();
    }

    public virtual void Shoot()
    {
        //Get bullet from pool and position it.
        GameObject bulletGO;
        bulletGO = _bulletPool.Get();
        bulletGO.transform.position = transform.position;
        bulletGO.transform.rotation = transform.rotation;
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        //Was it shoot by Player or Enemy.
        if (this.gameObject.tag == "Player")
            bullet.PlayerBullet = true;
        else
            bullet.PlayerBullet = false;
    } 

    public virtual void TakeDamage()
    {
        life--;
    }

    public void Die()
    {
        GameObject explosionGO;
        explosionGO = _explosionPool.Get();
        explosionGO.transform.position = transform.position;
        explosionGO.transform.rotation = transform.rotation;
        Destroy(this.gameObject);
    }
}
