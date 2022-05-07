using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingManagerDessert : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string currentInteracted;
    private bool eventHappened;
    [SerializeField] private AudioClip doneSFX;
    private float pitch = 1;
    #region function declaration
    IEnumerator WaitLoop(string name)
    {
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != name);
        PlayDoneSFX();
    }
    private void PlayDoneSFX()
    {
        if (doneSFX != null)
        {
            AudioSource audio = AudioManager.instance.GetSFXAudioSource();
            pitch *= 1.05946f;
            audio.pitch = pitch;
            audio.PlayOneShot(doneSFX);
            //audio.pitch = 1f;
        }
    }
    private void ResetPitch()
    {
        if (doneSFX != null)
            AudioManager.instance.GetSFXAudioSource().pitch = 1.0f;
    }
    //Event subscriber that sets the flag
    void OnEvent(string name)
    {
        eventHappened = true;
        currentInteracted = name;
    }

    //Coroutine that waits until the flag is set
    IEnumerator WaitForEvent()
    {
        yield return new WaitUntil(() => eventHappened == true);
        eventHappened = false;
    }
    void Start()
    {
        GameEvent.current.OnIngredientPress += OnEvent;
        StartCoroutine("RecepieProcessor");
    }
    #endregion
    #region steps of the recipe
    private IEnumerator RecepieProcessor()//for waiting/calling events
    {
        TMPRecepieInstructions.text = "Start by grabing banana";
        yield return WaitLoop("Banana");
        GameEvent.current.EnableRequest("BananaUnPeeled");
        TMPRecepieInstructions.text = "Unpeel the banana (by clicking on it)";
        yield return WaitLoop("BananaUnPeeled");
        GameEvent.current.EnableRequest("BananaUnPeeled");
        GameEvent.current.EnableRequest("BananaPeeled");
        GameEvent.current.EnableRequest("StickBanana");
        TMPRecepieInstructions.text = "Push stick into banana";
        yield return WaitLoop("StickBanana");
        GameEvent.current.EnableRequest("BananaPeeled");
        GameEvent.current.EnableRequest("StickBanana");
        GameEvent.current.EnableRequest("BananaStickDone");
        TMPRecepieInstructions.text = "Take caramel squares and put them in the pot to melt";
        yield return WaitLoop("Caramel");
        GameEvent.current.EnableRequest("CaramelOnScene");
        yield return WaitLoop("Pot");
        GameEvent.current.EnableRequest("CaramelOnScene");
        GameEvent.current.EnableRequest("PotCaramel");
        TMPRecepieInstructions.text = "Put banana in melted caramel";
        yield return WaitLoop("BananaStickDone");
        GameEvent.current.EnableRequest("BananaStickDone");
        GameEvent.current.EnableRequest("PotCaramel");
        GameEvent.current.EnableRequest("BananaCaramel");
        TMPRecepieInstructions.text = "Put marshmallow on front of banana";
        yield return WaitLoop("Marshmallow");
        GameEvent.current.EnableRequest("BananaCaramel");
        GameEvent.current.EnableRequest("BananaMarshmallow");
        TMPRecepieInstructions.text = "Put oreos on sides of banana";
        yield return WaitLoop("Oreos");
        GameEvent.current.EnableRequest("BananaMarshmallow");
        GameEvent.current.EnableRequest("BananaOreo");
        TMPRecepieInstructions.text = "Draw monkey face on banana with icing";
        yield return WaitLoop("Icing");
        GameEvent.current.EnableRequest("BananaOreo");
        GameEvent.current.EnableRequest("Monkey");
        TMPRecepieInstructions.text = "Your dish is done!";
        ResetPitch();
        ProgressTracker.instance.DessertFinished();
    }
    #endregion
}
