using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    // Start is called before the first frame update
    StepBase currentStep;
    CuttingStep cutting = new CuttingStep();
    SteeringStep steering = new SteeringStep();
    public float test = 0.0f;
    private void Start()
    {
        currentStep = new EmptyStep();//just to make sure we dont 
    }
    void Update()
    {
        currentStep.UpdateStep(this);
    }
    public void SetCurrentStep(StepBase step)
    {
        currentStep = step;
        currentStep.EnterStep(this);
    }
}
