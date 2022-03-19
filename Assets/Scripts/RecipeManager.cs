using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RecipeBase recipe;
    void Start()
    {
        recipe = new SapmleRecipe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
