using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
    private Vector3 scaleOrigin;
    private void Start()
    {
        scaleOrigin = transform.localScale;
    }
    private void OnMouseDown()
    {
        GameEvent.current.IngredientPress(this.name);
    }
    private void OnMouseEnter()
    {
        transform.localScale += transform.localScale * 0.2f;
    }
    private void OnMouseExit()
    {
        transform.localScale = scaleOrigin;
    }
}
