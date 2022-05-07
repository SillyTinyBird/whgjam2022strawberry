using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneTransition : MonoBehaviour
{
    [Header("Index of the game scene")] [Min(0)]
    [SerializeField] private int roomIndex;//no longer needed 
    [Header("Transition image")]
    [SerializeField] Image image;
    [Header("Fade speed")] [Min(0)]
    [SerializeField] private float fadeSpeed;
    [Header("Transition speed (before it loads next level")] [Min(0)]
    [SerializeField] private float transitionSpeed;
    public static SceneTransition current;

    public delegate void OnSceneLoaded(int id);
    /// <summary>  Load the scene (using transitions) </summary>
    public static event OnSceneLoaded LoadSceneWithId;

    void Awake()
    {
        StopCoroutine();
        current = this;//singleton kind of situation
    }
    private void OnEnable() => LoadSceneWithId += LoadScene;//removed hardcoded dependency (was dependent on MainMenu class)
    private void OnDisable() => LoadSceneWithId -= LoadScene;
    private void LoadScene(int id) => StartCoroutine(LoadLevelCoroutine(id));
    private void StopCoroutine() => StartCoroutine(StopLoadingCoroutine());

    public void RequestLoadsceneWithId(int id)//call this (from current) to invoke transition
    {
        if (LoadSceneWithId != null)
        {
            LoadSceneWithId(id);
        }
    }

    #region IEnumerators
    //When the new scene is loaded, fade out the image
    private IEnumerator StopLoadingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Fading.FadeOut(image, fadeSpeed);
        yield return new WaitForSeconds(2f);
        image.raycastTarget = false;
    }

    private IEnumerator LoadLevelCoroutine(int id)
    {
        image.raycastTarget = true;
        Fading.FadeIn(image, fadeSpeed);
        yield return new WaitForSeconds(transitionSpeed);
        SceneManager.LoadScene(id);
    }
    #endregion
}

