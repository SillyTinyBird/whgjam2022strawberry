using UnityEngine;
using System;
public abstract class StepBase //blueprint for the states
{
    public abstract void EnterStep(CookingManager context);//Setup for the scene
    public abstract void UpdateStep(CookingManager context);
    public abstract void NextStep(CookingManager context);
}
