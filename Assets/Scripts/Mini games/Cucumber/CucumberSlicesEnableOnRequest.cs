using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberSlicesEnableOnRequest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvent.current.OnEnableRequest += ChildrenEnable;
    }
    void ChildrenEnable(string name)
    {
        if (name == this.name)
        {
            for (int i = 0; i != this.transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
            }
        }
    }
}
