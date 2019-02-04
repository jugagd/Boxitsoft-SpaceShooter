using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Pool _pool;

    public float time;
    public float speed;
    public bool PlayerBullet;

    private void OnEnable()
    {
        _pool = GameObject.Find("BulletPool").GetComponent<Pool>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Limit") ||
            (collision.gameObject.tag == "Enemy" && PlayerBullet) ||
            (collision.gameObject.tag == "Player" && !PlayerBullet))
            ReturnToPool();
    }

    public void ReturnToPool()
    {
        _pool.Return(gameObject);
    }

    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }

   
}

