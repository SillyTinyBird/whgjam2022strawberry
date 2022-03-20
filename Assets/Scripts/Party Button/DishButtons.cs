using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DishButtons : MonoBehaviour
{
    public delegate void OnSceneChanged(int index);
    public static event OnSceneChanged SceneTransition;

    [Header("Scenes indexes")]
    [SerializeField] private int drinksIndex, mainCourseIndex, dessertIndex, partyIndex;
    [Header("Drinks")] 
    [SerializeField] private Button drinks;
    [SerializeField] private Image drinkCheck;
    [Space(20)]
    [Header("Main course")] 
    [SerializeField] private Button mainCourse;
    [SerializeField] private Image mainCourseCheck;
    [Space(20)]
    [Header("Dessert")]
    [SerializeField] private Button dessert;
    [SerializeField] private Image dessertCheck;
    [Space(20)]
    [Header("Party button")]
    [SerializeField] private GameObject partyBtn;

    [SerializeField]
    private bool drinksReady, mainCourseReady, dessertReady;

    private void Awake() 
    {   
        partyBtn.SetActive(false);
    }

    private void Update()
    {
        if (drinksReady && mainCourseReady && dessertReady)
            partyBtn.SetActive(true);
    }

    public void LoadDrinks() 
    { 
        SceneTransition(drinksIndex);
    }
    public void LoadMainCourse() 
    { 
        SceneTransition(mainCourseIndex);
    }

    public void LoadDessert() 
    {
        SceneTransition(dessertIndex);
    }

    public void LoadParty() 
    {
        SceneTransition(partyIndex);
    }

    private void DishFinished(string dishName)
    {
        switch (dishName)
        {
            case "Drinks":
                drinks.interactable = false;
                drinkCheck.gameObject.SetActive(true);
                drinksReady = true;
                break;
            case "MainCourse":
                mainCourse.interactable = false;
                drinkCheck.gameObject.SetActive(true);
                mainCourseReady = true;
                break;
            case "Dessert":
                dessert.interactable = false;
                drinkCheck.gameObject.SetActive(true);
                dessertReady = true;
                break;           
            default:
                break;
        }
    }
}
