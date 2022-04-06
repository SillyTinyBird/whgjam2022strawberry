using System.Collections;
using TMPro;
using UnityEngine;

public class CookingManagerDrinks : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string lastInteracted;
    private string currentInteracted;
    bool eventHappened;

    //Event subscriber that sets the flag
    void OnEvent(string name)
    {
        eventHappened = true;
        lastInteracted = currentInteracted;
        currentInteracted = name;
        Debug.Log(currentInteracted);
    }

    //Coroutine that waits until the flag is set
    IEnumerator WaitForEvent()
    {
        yield return new WaitUntil(() => eventHappened == true);
        Debug.Log("Requirements registred");
        eventHappened = false;
    }
    void Start()
    {
        GameEvent.current.OnIngredientPress += OnEvent;
        StartCoroutine("RecepieProcessor");
        //stepRequirements.Add(
    }
    //steps
    private IEnumerator RecepieProcessor()
    {
        TMPRecepieInstructions.text = "Start by pouring the soda into a bowl";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Soda");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BowlEmpty");
        GameEvent.current.EnableRequest("BowlSoda");
        GameEvent.current.EnableRequest("BowlEmpty");
        TMPRecepieInstructions.text = "Dye the soda blue";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BlueDye");
        GameEvent.current.EnableRequest("BowlSoda");
        GameEvent.current.EnableRequest("BowlDyedSoda");
        //set aside
        TMPRecepieInstructions.text = "Add rock-shaped candy to the turtle bowl";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "RockCandy");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "TurtleBowlEmpty");
        GameEvent.current.EnableRequest("TurtleBowlEmpty");
        GameEvent.current.EnableRequest("TurtleBowlL1");

        TMPRecepieInstructions.text = "Add a layer of ice";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ice");
        GameEvent.current.EnableRequest("TurtleBowlL1");
        GameEvent.current.EnableRequest("TurtleBowlL2");
        TMPRecepieInstructions.text = "Add a layer of fish-shaped candy";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL2");
        GameEvent.current.EnableRequest("TurtleBowlL3");


        TMPRecepieInstructions.text = "Alternate between fish-shaped candy and ice until the bowl is full";

        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ice");
        GameEvent.current.EnableRequest("TurtleBowlL3");
        GameEvent.current.EnableRequest("TurtleBowlL4");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL4");
        GameEvent.current.EnableRequest("TurtleBowlL5");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ice");
        GameEvent.current.EnableRequest("TurtleBowlL5");
        GameEvent.current.EnableRequest("TurtleBowlL6");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "FishCandy");
        GameEvent.current.EnableRequest("TurtleBowlL6");
        GameEvent.current.EnableRequest("TurtleBowlL7");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ice");
        GameEvent.current.EnableRequest("TurtleBowlL7");
        GameEvent.current.EnableRequest("TurtleBowlL8");

        TMPRecepieInstructions.text = "Finally, pour the dyed soda into the fish bowl";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BowlDyedSoda");
        GameEvent.current.EnableRequest("BowlDyedSoda");
        GameEvent.current.EnableRequest("TurtleBowlL8");
        GameEvent.current.EnableRequest("TurtleBowlFinal");
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}