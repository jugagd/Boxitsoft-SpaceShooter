using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Pool _pool;
        
    private void OnEnable()
    {
        _pool = GameObject.Find("ExplosionPool").GetComponent<Pool>();
        Invoke("ReturnToPool", 2f);
    }
  
    public void ReturnToPool()
    {
        _pool.Return(gameObject);
    }
}
