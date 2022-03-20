using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CookingManagerDrinks : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string lastInteracted;
    private string currentInteracted;
    bool eventHappened;
    public GameObject doneSoda;

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
        while (currentInteracted != "Soda")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Dye the soda blue";
        while (currentInteracted != "BlueDye")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        doneSoda.SetActive(true);
        //set aside
        TMPRecepieInstructions.text = "Add rock-shaped candy";
        while (currentInteracted != "RockCandy")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Add a layer of ice";
        while (currentInteracted != "Ice")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Add a layer of fish-shaped candy";
        while (currentInteracted != "FishCandy")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "And then another layer of ice";
        while (currentInteracted != "Ice")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Finally, pour the dyed soda into the fish bowl";
        while (currentInteracted != "SodaDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}