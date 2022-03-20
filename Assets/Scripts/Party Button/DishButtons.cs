using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DishButtons : MonoBehaviour
{
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
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (drinksReady && mainCourseReady && dessertReady)
            partyBtn.SetActive(true);
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
