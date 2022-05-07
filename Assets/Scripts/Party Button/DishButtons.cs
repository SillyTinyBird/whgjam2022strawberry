using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DishButtons : MonoBehaviour
{
    public static DishButtons instance;


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
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);*/

    }
    /*private void Awake() 
    {   
        
        DontDestroyOnLoad(this);
    }*/
    private void OnEnable()
    {
        ChecksFacade();
        UpdateMenu();
        if (drinksReady && mainCourseReady && dessertReady)
            partyBtn.SetActive(true);
    }
    private void Update()
    {
        
        
    }
    private void ChecksFacade()
    {
        drinksReady = ProgressTracker.instance.GetDrinks();
        mainCourseReady = ProgressTracker.instance.GetMainCourse();
        dessertReady = ProgressTracker.instance.GetDessert();
    }
    private void UpdateMenu()
    {
        if(drinksReady)
        {
            //drinks.interactable = false;
            drinkCheck.gameObject.SetActive(true);
            drinksReady = true;
        }
        if(mainCourseReady)
        {
            //mainCourse.interactable = false;
            mainCourseCheck.gameObject.SetActive(true);
            mainCourseReady = true;
        }
        if(dessertReady)
        {
            //dessert.interactable = false;
            dessertCheck.gameObject.SetActive(true);
            dessertReady = true;
        }
    }

    /*
    private void DishFinished(string dishName)//put this on awake and check on each load of the scene // replace sith boleans
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
    }*/
}
