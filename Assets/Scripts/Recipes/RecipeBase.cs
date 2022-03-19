using UnityEngine;
using System.Collections.Generic;
using System;
[Serializable]
public abstract class RecipeBase
{
    public abstract List<StepBase> Steps
    {
        get;
    }
    //add here other properties like sprites and stuff
}
