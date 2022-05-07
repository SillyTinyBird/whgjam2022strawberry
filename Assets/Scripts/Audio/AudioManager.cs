using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;//singletone-ish

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
            
    }
    public AudioSource GetMusicAudioSource()
    {
        return transform.GetChild(0).GetComponent<AudioSource>();
    }
    public AudioSource GetSFXAudioSource()
    {
        return transform.GetChild(1).GetComponent<AudioSource>();
    }
}
