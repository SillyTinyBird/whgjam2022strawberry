using System.Collections;
using TMPro;
using UnityEngine;


public class CookingManagerMainCourse : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TMPRecepieInstructions;
    private string lastInteracted;
    private string currentInteracted;
    bool eventHappened;
    public GameObject doneBread;
    public GameObject doneHam;
    public GameObject doneCheese;
    public GameObject doneCucumber;
    public GameObject sandwich;

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
        //animate bread apearing on working surface
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Bread");
        //animate bread apearing on working surface
        TMPRecepieInstructions.text = "Use cookie cutter to cut both slices of bread into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("BreadDone");
        //animate cutting with yield or something
        TMPRecepieInstructions.text = "Grab slice of ham";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Ham");
        //etc
        TMPRecepieInstructions.text = "Use cookie cutter to cut ham into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("HamDone");
        TMPRecepieInstructions.text = "Grab slice of cheese";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cheese");
        //etc
        TMPRecepieInstructions.text = "Use cookie cutter to cut cheese into cat shape";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cutter");
        GameEvent.current.EnableRequest("CheeseDone");
        TMPRecepieInstructions.text = "Grab whole cucumber";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cucumber");
        //etc
        TMPRecepieInstructions.text = "Cut into round circles";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Knife");
        GameEvent.current.EnableRequest("CucumberDone");
        TMPRecepieInstructions.text = "Grab knife, click on cream cheese to add it to knifes";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Knife");
        //animate knife grabbed
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "Cream");
        //here is spreading cream phase
        TMPRecepieInstructions.text = "Assemble your sandwich in this order; bread, cheese, ham, cucumber, top bread";
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BreadDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "CheeseDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "HamDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "CucumberDone");
        do
        {
            yield return StartCoroutine(WaitForEvent());
        } while (currentInteracted != "BreadDone");
        GameEvent.current.EnableRequest("Sandwich");
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}
