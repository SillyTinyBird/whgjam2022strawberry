using UnityEngine;
using System;
public abstract class StepBase //blueprint for the states
{
    public abstract void EnterStep(CookingManager context);//Setup for the scene
    public abstract void UpdateStep(CookingManager context);//main logic
    public abstract void NextStep(CookingManager context);//always ends with RecipeManager.NextStep()
}