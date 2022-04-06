using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingManagerDessert : MonoBehaviour
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
        Debug.Log("Requirements registered");
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
        TMPRecepieInstructions.text = "Start by grabing banana";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Banana");
        GameEvent.current.EnableRequest("BananaUnPeeled");
        TMPRecepieInstructions.text = "Unpeel the banana (by clicking on it)";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BananaUnPeeled");
        GameEvent.current.EnableRequest("BananaUnPeeled");
        GameEvent.current.EnableRequest("BananaPeeled");
        TMPRecepieInstructions.text = "Push stick into banana";
        while (currentInteracted != "Stick")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        GameEvent.current.EnableRequest("BananaPeeled");
        GameEvent.current.EnableRequest("BananaStickDone");
        TMPRecepieInstructions.text = "Take caramel squares and put them in the pot to melt";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Caramel");
        GameEvent.current.EnableRequest("CaramelOnScene");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Pot");
        GameEvent.current.EnableRequest("CaramelOnScene");
        GameEvent.current.EnableRequest("PotCaramel");
        TMPRecepieInstructions.text = "Put banana in melted caramel";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BananaStickDone");
        GameEvent.current.EnableRequest("BananaStickDone");
        GameEvent.current.EnableRequest("PotCaramel");
        GameEvent.current.EnableRequest("BananaCaramel");
        TMPRecepieInstructions.text = "Put marshmallow on front of banana";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Marshmallow");
        GameEvent.current.EnableRequest("BananaCaramel");
        GameEvent.current.EnableRequest("BananaMarshmallow");
        TMPRecepieInstructions.text = "Put oreos on sides of banana";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Oreos");
        GameEvent.current.EnableRequest("BananaMarshmallow");
        GameEvent.current.EnableRequest("BananaOreo");
        TMPRecepieInstructions.text = "Draw monkey face on banana with icing";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Icing");
        GameEvent.current.EnableRequest("BananaOreo");
        GameEvent.current.EnableRequest("Monkey");
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}
