using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameEvent.current.IngredientPress(this.name);
    }
}
