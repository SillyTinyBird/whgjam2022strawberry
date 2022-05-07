using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*public delegate void OnSceneLoaded();
    /// <summary>  Load the scene (using transitions) </summary>
    public static event OnSceneLoaded LoadScene;*/

    [Header("The parts of the main menu")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject creditsMenu;

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;

    private void Awake() => DisableParts();
    public void StartGame() => SceneTransition.current.RequestLoadsceneWithId(1);
    public void Settings() => settingsMenu.SetActive(true);
    public void Credits() => creditsMenu.SetActive(true);
    public void GoBack() => DisableParts();
    public void SetVolumeMusic(float volume) => audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    public void SetVolumeSoundEffects(float volume) => audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    private void DisableParts()
    {
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }
}
