using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringStep : StepBase
{
    public override void EnterStep(CookingManager context)
    {
        Debug.Log("entered steering");
    }
    public override void UpdateStep(CookingManager context)
    {
        context.test += 0.1f;
        Debug.Log(context.test);
        if (context.test >= 5)
        {
            context.test = 0;
            NextStep(context);
        }
    }
    public override void NextStep(CookingManager context)
    {
        //remove stuff
        RecipeManager.NextStep(context);
    }
}
