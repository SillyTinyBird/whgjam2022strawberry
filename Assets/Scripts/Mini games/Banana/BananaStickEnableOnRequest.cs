using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaStickEnableOnRequest : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    [SerializeField] private List<Behaviour> behaviours;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameEvent.current.OnEnableRequest += ComponentOnOff;
    }
    private void OnDestroy()
    {
        GameEvent.current.OnEnableRequest -= ComponentOnOff;
    }
    void ComponentOnOff(string name)
    {
        if (name == this.name)
        {
            foreach (Behaviour item in behaviours)
            {
                item.enabled = !item.enabled;
            }
            spriteRenderer.enabled = !spriteRenderer.enabled;
            transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeSelf);
            transform.GetChild(1).gameObject.SetActive(!transform.GetChild(1).gameObject.activeSelf);
        }
    }
}
