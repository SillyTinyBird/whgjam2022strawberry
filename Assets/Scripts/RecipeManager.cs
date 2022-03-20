using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager
{
    static public int CurentStep;
    static private RecipeBase recipe;

    void Start()
    {
        recipe = new SapmleRecipe();
    }
    static public void StartRecepie(CookingManager managerCook, RecipeBase recepieToStart)
    {
        CurentStep = 0;
        recipe = recepieToStart;
        managerCook.SetCurrentStep(recipe.Steps[CurentStep]);
    }
    static public void NextStep(CookingManager managerCook)
    {
        CurentStep++;
        if (CurentStep >= recipe.Steps.Count)
        {
            Debug.Log("end of recipe");
            managerCook.SetCurrentStep(new EmptyStep());
            return;//end of recipe
        }
        managerCook.SetCurrentStep(recipe.Steps[CurentStep]);
    }
}
