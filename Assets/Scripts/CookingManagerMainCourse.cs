using System.Collections;
using TMPro;
using UnityEngine;


public class CookingManagerMainCourse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string lastInteracted;
    private string currentInteracted;
    private bool eventHappened;

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
        TMPRecepieInstructions.text = "Start by grabing two slices of bread";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Bread");
        GameEvent.current.EnableRequest("SliceBread1");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Bread");
        GameEvent.current.EnableRequest("SliceBread2");
        TMPRecepieInstructions.text = "Use cookie cutter to cut both slices of bread into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("SliceBread1");
        GameEvent.current.EnableRequest("SliceBread2");
        GameEvent.current.EnableRequest("BreadDone1");
        GameEvent.current.EnableRequest("BreadDone2");

        TMPRecepieInstructions.text = "Grab slice of ham";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ham");
        GameEvent.current.EnableRequest("SliceHam");
        //etc
        TMPRecepieInstructions.text = "Use cookie cutter to cut ham into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("SliceHam");
        GameEvent.current.EnableRequest("HamDone");

        TMPRecepieInstructions.text = "Grab slice of cheese";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cheese");
        GameEvent.current.EnableRequest("SliceCheese");
        TMPRecepieInstructions.text = "Use cookie cutter to cut cheese into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("SliceCheese");
        GameEvent.current.EnableRequest("CheeseDone");

        TMPRecepieInstructions.text = "Grab whole cucumber";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cucumber");
        GameEvent.current.EnableRequest("WholeCucumber");
        TMPRecepieInstructions.text = "Cut into round circles";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Knife");
        GameEvent.current.EnableRequest("WholeCucumber");
        GameEvent.current.EnableRequest("CucumberDone");

        TMPRecepieInstructions.text = "Grab knife, click on cream cheese to add it to knifes";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Knife");
        GameEvent.current.EnableRequest("KnifeGrab");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cream");
        GameEvent.current.EnableRequest("KnifeGrab");
        GameEvent.current.EnableRequest("KnifeCream");
        
        GameEvent.current.EnableRequest("BreadDone1");
        GameEvent.current.EnableRequest("SliceBreadCream");
        TMPRecepieInstructions.text = "Spread cream cheese onto one slice of bread";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "SliceBreadCream");
        GameEvent.current.EnableRequest("KnifeCream");
        GameEvent.current.EnableRequest("SliceBreadCream");
        GameEvent.current.EnableRequest("BreadDoneCream");
        //here is spreading cream phase
        TMPRecepieInstructions.text = "Assemble your sandwich in this order; bread, cheese, ham, cucumber, top bread";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BreadDone2" && currentInteracted != "BreadDoneCream");
        GameEvent.current.EnableRequest("BreadDoneCream");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "CheeseDone");
        GameEvent.current.EnableRequest("CheeseDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "HamDone");
        GameEvent.current.EnableRequest("HamDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "CucumberDone");
        GameEvent.current.EnableRequest("CucumberDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BreadDone2" && currentInteracted != "BreadDoneCream");
        GameEvent.current.EnableRequest("BreadDone2");
        GameEvent.current.EnableRequest("Sandwich");
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}
