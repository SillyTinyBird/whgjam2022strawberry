using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnRequest : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SpriteRenderer spriteRenderer;
    [SerializeField] AudioClip clip;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameEvent.current.OnEnableRequest += ComponentOnOff;
    }
    private void OnDestroy()
    {
        GameEvent.current.OnEnableRequest -= ComponentOnOff;
    }
    void ComponentOnOff(string name)
    {
        if(name == this.name)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            boxCollider.enabled = !boxCollider.enabled;
            if(spriteRenderer.enabled && clip!= null)
            {
                AudioManager.instance.GetSFXAudioSource().PlayOneShot(clip);
            }
        }
    }
}
