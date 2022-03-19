using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingStep : StepBase
{
    public override void EnterStep(CookingManager context)
    {
        Debug.Log("entered cutting");
        //setup stuff
    }
    public override void UpdateStep(CookingManager context)
    {
        context.test += 0.1f;
        Debug.Log(context.test);
        if(context.test >= 5)
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
