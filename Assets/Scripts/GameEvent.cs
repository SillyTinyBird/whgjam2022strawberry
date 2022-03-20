using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvent : MonoBehaviour
{
    public static GameEvent current;
    void Awake()
    {
        current = this;
    }
    public event Action<string> OnIngredientPress;
    public void IngredientPress(string name)
    {
        if (OnIngredientPress != null)
        {
            OnIngredientPress(name);
        }
    }
}
