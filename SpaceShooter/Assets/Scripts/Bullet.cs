using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Pool pool;
    public float time;
    public float speed;

    public void TimePassed()
    {
        pool.Return(gameObject);
    }
    
    public void OutPool(Pool p)
    {
        Invoke("TimePassed", time);
        pool = p;
    }
    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f);
    }
}

