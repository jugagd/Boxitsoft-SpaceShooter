using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Settings : MonoBehaviour
{
    static public Settings s_Instance;
    public AudioMixer mixer;

    void Awake()
    {
        s_Instance = this;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Settings");
        if (objs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);        
    }
}
