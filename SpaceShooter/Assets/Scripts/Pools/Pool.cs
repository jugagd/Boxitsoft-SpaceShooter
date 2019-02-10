using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<GameObject> _objects = new List<GameObject>();

    public GameObject prefab;
    public int startingPoolItems;
    private void Start()
    {
        for (int i = 0; i < startingPoolItems; i++)
        {
            Return(Instantiate(prefab));
        }
    }
    public GameObject Get()
    {
        GameObject go = null;
        if (_objects.Count > 0)
        {
            go = _objects[0];
            _objects.Remove(go);
        }
        else
        {
            go = Instantiate(prefab);
        }
        go.SetActive(true);
        return go;
    }

    public void Return(GameObject go)
    {
        go.transform.parent = this.gameObject.transform;
        go.SetActive(false);
        _objects.Add(go);
    }
}
