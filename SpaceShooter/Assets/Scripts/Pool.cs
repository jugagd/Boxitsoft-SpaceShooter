using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour {
    private List<GameObject> objects = new List<GameObject>();
    public GameObject prefab;
    public GameObject Get()
    {
        GameObject go = null;
        if (objects.Count > 0)
        {
            go = objects[0];
            objects.Remove(go);
        }
        else
        {
            go = Instantiate(prefab);
        }
        go.SetActive(true);
        go.transform.parent = this.gameObject.transform;
        go.SendMessage("OutPool", this, SendMessageOptions.DontRequireReceiver);
        return go;
    }

    public void Return(GameObject go)
    {
        go.SetActive(false);
        go.SendMessage("InPool", this, SendMessageOptions.DontRequireReceiver);
        objects.Add(go);
    }
}
