using System.Collections;
using TMPro;
using UnityEngine;

public class CookingManagerDrinks : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string currentInteracted;
    bool eventHappened;
    [SerializeField] private AudioClip doneSFX;
    private float pitch = 1;
    #region function declaration
    private IEnumerator WaitLoop(string name)
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
    private IEnumerator RecepieProcessor()
    {
        TMPRecepieInstructions.text = "Start by pouring the soda into a bowl";
        yield return WaitLoop("Soda");//add reaction
        yield return WaitLoop("BowlEmpty");
        GameEvent.current.EnableRequest("BowlSoda");
        GameEvent.current.EnableRequest("BowlEmpty");
        TMPRecepieInstructions.text = "Dye the soda blue";
        yield return WaitLoop("BlueDye");
        GameEvent.current.EnableRequest("BowlSoda");
        GameEvent.current.EnableRequest("Stiring");
        yield return WaitLoop("Stiring");
        GameEvent.current.EnableRequest("Stiring");
        GameEvent.current.EnableRequest("BowlDyedSoda");
        TMPRecepieInstructions.text = "Add rock-shaped candy to the turtle bowl";
        yield return WaitLoop("RockCandy");
        yield return WaitLoop("TurtleBowlEmpty");
        GameEvent.current.EnableRequest("TurtleBowlEmpty");
        GameEvent.current.EnableRequest("TurtleBowlL1");
        TMPRecepieInstructions.text = "Add a layer of ice";
        yield return WaitLoop("Ice");
        GameEvent.current.EnableRequest("TurtleBowlL1");
        GameEvent.current.EnableRequest("TurtleBowlL2");
        TMPRecepieInstructions.text = "Add a layer of fish-shaped candy";
        yield return WaitLoop("FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL2");
        GameEvent.current.EnableRequest("TurtleBowlL3");
        TMPRecepieInstructions.text = "Alternate between fish-shaped candy and ice until the bowl is full";
        yield return WaitLoop("Ice");
        GameEvent.current.EnableRequest("TurtleBowlL3");
        GameEvent.current.EnableRequest("TurtleBowlL4");
        yield return WaitLoop("FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL4");
        GameEvent.current.EnableRequest("TurtleBowlL5");
        yield return WaitLoop("Ice");
        GameEvent.current.EnableRequest("TurtleBowlL5");
        GameEvent.current.EnableRequest("TurtleBowlL6");
        yield return WaitLoop("FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL6");
        GameEvent.current.EnableRequest("TurtleBowlL7");
        yield return WaitLoop("Ice");
        GameEvent.current.EnableRequest("TurtleBowlL7");
        GameEvent.current.EnableRequest("TurtleBowlL8");
        TMPRecepieInstructions.text = "Finally, pour the dyed soda into the fish bowl";
        yield return WaitLoop("BowlDyedSoda");
        GameEvent.current.EnableRequest("BowlDyedSoda");
        GameEvent.current.EnableRequest("TurtleBowlL8");
        GameEvent.current.EnableRequest("TurtleBowlFinal");
        TMPRecepieInstructions.text = "Your dish is done!";
        ResetPitch();
        ProgressTracker.instance.DrinksFinished();
    }
    #endregion
}