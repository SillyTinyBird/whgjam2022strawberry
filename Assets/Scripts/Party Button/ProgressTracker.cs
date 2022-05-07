using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public static ProgressTracker instance;
    [SerializeField]
    private bool drinksReady, mainCourseReady, dessertReady;

    public void DrinksFinished() => drinksReady = true;
    public void MainCourseFinished() => mainCourseReady = true;
    public void DessertFinished() => dessertReady = true;
    public bool GetDrinks() => drinksReady;
    public bool GetMainCourse() => mainCourseReady;
    public bool GetDessert() => dessertReady;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);
    }
}
