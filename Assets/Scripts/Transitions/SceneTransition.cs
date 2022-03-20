using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneTransition : MonoBehaviour
{
    [Header("Index of the game scene")] [Min(0)]
    [SerializeField] private int roomIndex;
    [Header("Transition image")]
    [SerializeField] Image image;
    [Header("Fade speed")] [Min(0)]
    [SerializeField] private float fadeSpeed;
    [Header("Transition speed (before it loads next level")] [Min(0)]
    [SerializeField] private float transitionSpeed;


    private void Awake() => StopCoroutine();
    private void OnEnable() => MainMenu.LoadScene += LoadScene;
    private void OnDisable() => MainMenu.LoadScene -= LoadScene;
    private void LoadScene() => StartCoroutine(LoadLevelCoroutine());
    private void StopCoroutine() => StartCoroutine(StopLoadingCoroutine());

    #region IEnumerators
    //When the new scene is loaded, fade out the image
    private IEnumerator StopLoadingCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Fading.FadeOut(image, fadeSpeed);
        yield return new WaitForSeconds(2f);
        image.raycastTarget = false;
    }

    private IEnumerator LoadLevelCoroutine()
    {
        image.raycastTarget = true;
        Fading.FadeIn(image, fadeSpeed);
        yield return new WaitForSeconds(transitionSpeed);
        SceneManager.LoadScene(roomIndex);
    }
    #endregion
}

