using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private List<GameObject> _objects = new List<GameObject>();

    public GameObject prefab;
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
        go.transform.parent = this.gameObject.transform;
        return go;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        _objects.Add(go);
    }
}
