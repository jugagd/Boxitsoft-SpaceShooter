using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    static public LevelManager s_Instance;
    public int enemysAlive;

    private void Awake()
    {
        //Sets up the singleton instance
        s_Instance = this;
    }
}
