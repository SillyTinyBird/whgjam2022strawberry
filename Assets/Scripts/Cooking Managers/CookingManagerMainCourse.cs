using System.Collections;
using TMPro;
using UnityEngine;


public class CookingManagerMainCourse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string currentInteracted;
    private bool eventHappened;
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
    private IEnumerator WaitLoop(string name1, string name2)
    {
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != name1 && currentInteracted != name2);
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
        TMPRecepieInstructions.text = "Start by grabing two slices of bread";
        yield return WaitLoop("Bread");
        GameEvent.current.EnableRequest("SliceBread1");
        yield return WaitLoop("Bread");
        GameEvent.current.EnableRequest("SliceBread2");
        TMPRecepieInstructions.text = "Use cookie cutter to cut both slices of bread into cat shape";
        yield return WaitLoop("Cutter");
        GameEvent.current.EnableRequest("SliceBread1");
        GameEvent.current.EnableRequest("SliceBread2");
        GameEvent.current.EnableRequest("BreadDone1");
        GameEvent.current.EnableRequest("BreadDone2");
        TMPRecepieInstructions.text = "Grab slice of ham";
        yield return WaitLoop("Ham");
        GameEvent.current.EnableRequest("SliceHam");
        TMPRecepieInstructions.text = "Use cookie cutter to cut ham into cat shape";
        yield return WaitLoop("Cutter");
        GameEvent.current.EnableRequest("SliceHam");
        GameEvent.current.EnableRequest("HamDone");
        TMPRecepieInstructions.text = "Grab slice of cheese";
        yield return WaitLoop("Cheese");
        GameEvent.current.EnableRequest("SliceCheese");
        TMPRecepieInstructions.text = "Use cookie cutter to cut cheese into cat shape";
        yield return WaitLoop("Cutter");
        GameEvent.current.EnableRequest("SliceCheese");
        GameEvent.current.EnableRequest("CheeseDone");
        TMPRecepieInstructions.text = "Grab whole cucumber";
        yield return WaitLoop("Cucumber");
        GameEvent.current.EnableRequest("Cutting");
        TMPRecepieInstructions.text = "Cut into round circles";
        yield return WaitLoop("Cutting");
        GameEvent.current.EnableRequest("Cutting");
        GameEvent.current.EnableRequest("CucumberDone");
        TMPRecepieInstructions.text = "Grab knife, click on cream cheese to add it to knifes";
        yield return WaitLoop("Knife");
        GameEvent.current.EnableRequest("KnifeGrab");
        yield return WaitLoop("Cream");
        GameEvent.current.EnableRequest("KnifeGrab");
        GameEvent.current.EnableRequest("KnifeCream");
        GameEvent.current.EnableRequest("BreadDone1");
        GameEvent.current.EnableRequest("SliceBreadCream");
        TMPRecepieInstructions.text = "Spread cream cheese onto one slice of bread";
        yield return WaitLoop("SliceBreadCream");
        GameEvent.current.EnableRequest("KnifeCream");
        GameEvent.current.EnableRequest("SliceBreadCream");
        GameEvent.current.EnableRequest("BreadDoneCream");
        TMPRecepieInstructions.text = "Assemble your sandwich in this order; bread, cheese, ham, cucumber, top bread";//visualizing this probs would look cool but no time 
        yield return WaitLoop("BreadDone2","BreadDoneCream");
        GameEvent.current.EnableRequest("BreadDoneCream");
        yield return WaitLoop("CheeseDone");
        GameEvent.current.EnableRequest("CheeseDone");
        yield return WaitLoop("HamDone");
        GameEvent.current.EnableRequest("HamDone");
        yield return WaitLoop("CucumberDone");
        GameEvent.current.EnableRequest("CucumberDone");
        yield return WaitLoop("BreadDone2", "BreadDoneCream");
        GameEvent.current.EnableRequest("BreadDone2");
        GameEvent.current.EnableRequest("Sandwich");
        TMPRecepieInstructions.text = "Your dish is done!";
        ResetPitch();
        ProgressTracker.instance.MainCourseFinished();
        //GameObject.Find("DishChecker").GetComponent<DishButtons>().DishFinished("MainCourse");
    }
    #endregion
}
