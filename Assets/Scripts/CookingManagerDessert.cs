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
    public GameObject doneBanana;
    public GameObject onSceneBanana;
    public GameObject onSceneBananaPeeled;

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
        while (currentInteracted != "Banana")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        onSceneBanana.SetActive(true);
        TMPRecepieInstructions.text = "Unpeel the banana (by clicking on it)";
        while (currentInteracted != "BananaOnScene")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        onSceneBanana.SetActive(false);
        onSceneBananaPeeled.SetActive(true);
        TMPRecepieInstructions.text = "Push stick into banana";
        while (currentInteracted != "Stick")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        onSceneBananaPeeled.SetActive(false);
        doneBanana.SetActive(true);
        TMPRecepieInstructions.text = "Take caramel squares";
        while (currentInteracted != "Caramel")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Put in pot and melt the caramel";
        while (currentInteracted != "Pot")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Put banana in melted caramel";
        while (currentInteracted != "BananaDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }

        TMPRecepieInstructions.text = "Put marshmallow on front of banana";
        while (currentInteracted != "Marshmallow")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Put oreos on sides of banana";
        while (currentInteracted != "Oreos")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Draw monkey face on banana with icing";
        while (currentInteracted != "Icing")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}
