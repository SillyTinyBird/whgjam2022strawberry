using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using TMPro;


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
        TMPRecepieInstructions.text = "Start by grabing two slices of bread";
        while(currentInteracted != "Bread")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //animate bread apearing on working surface
        while(currentInteracted != "Bread")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //animate bread apearing on working surface
        TMPRecepieInstructions.text = "Use cookie cutter to cut both slices of bread into cat shape";
        while (currentInteracted != "Cutter")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        doneBread.SetActive(true);
        //animate cutting with yield or something
        TMPRecepieInstructions.text = "Grab slice of ham";
        while (currentInteracted != "Ham")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //etc
        TMPRecepieInstructions.text = "Use cookie cutter to cut ham into cat shape";
        while (currentInteracted != "Cutter")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        doneHam.SetActive(true);
        TMPRecepieInstructions.text = "Grab slice of cheese";
        while (currentInteracted != "Cheese")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //etc
        TMPRecepieInstructions.text = "Use cookie cutter to cut cheese into cat shape";
        while (currentInteracted != "Cutter")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        doneCheese.SetActive(true);
        TMPRecepieInstructions.text = "Grab whole cucumber";
        while (currentInteracted != "Cucumber")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //etc
        TMPRecepieInstructions.text = "Cut into round circles";
        while (currentInteracted != "Knife")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        doneCucumber.SetActive(true); ;
        TMPRecepieInstructions.text = "Grab knife, click on cream cheese to add it to knifes";
        while (currentInteracted != "Knife")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //animate knife grabbed
        while (currentInteracted != "Cream")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        //here is spreading cream phase
        TMPRecepieInstructions.text = "Assemble your sandwich in this order; bread, cheese, ham, cucumber, top bread";
        while (currentInteracted != "BreadDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        while (currentInteracted != "CheeseDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        while (currentInteracted != "HamDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        while (currentInteracted != "CucumberDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        while (currentInteracted != "BreadDone")
        {
            yield return StartCoroutine(WaitForEvent());
        }
        sandwich.SetActive(true);
        TMPRecepieInstructions.text = "Your dish is done!";
        Debug.Log("Recepie done!");
    }
}
