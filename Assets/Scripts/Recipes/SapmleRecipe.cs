using System.Collections.Generic;
public class SapmleRecipe : RecipeBase
{
    public override List<StepBase> Steps
    {
        get
        {
            List<StepBase> list = new List<StepBase>();
            list.Add(new CuttingStep());
            list.Add(new SteeringStep());//add steps in recepie like that
            return list;
        }
    }
}
