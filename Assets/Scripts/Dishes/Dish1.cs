using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Dish1 : MonoBehaviour
{
    [SerializeReference]//i have no time to make this thing work soo i gues we have to make new script for each dish and hardcode recepie to it
    public RecipeBase recepieForDish;
    private CookingManager managerCook;

    private void Start()
    {
        managerCook = FindObjectOfType<CookingManager>();
    }
    private void OnMouseDown()
    {
        RecipeManager.StartRecepie(managerCook, new SapmleRecipe());
    }
}
