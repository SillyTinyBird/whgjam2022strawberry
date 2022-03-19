using UnityEngine;
using System.Collections.Generic;

public abstract class RecipeBase
{
    public abstract List<StepBase> Steps
    {
        get;
    }
}
