using UnityEngine;

public class ChangeAudioClipOnAwake : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    private void Start()
    {
        AudioSource audio = AudioManager.instance.GetMusicAudioSource();
        if (audio.clip != clip)
        {
            audio.clip = clip;
            audio.Play();
        }
    }
}