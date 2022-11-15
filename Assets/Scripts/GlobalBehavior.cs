using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalBehavior : MonoBehaviour
{
    public static GlobalBehavior GlobalBehaviorInstance = null;
    public Text PotatoBucket = null;
    //bucket picked count
    private int count = 0;

    //if player could escape or not
    public bool isEscape = false;

    void Start()
    {
        GlobalBehavior.GlobalBehaviorInstance = this;
    }

    void Update()
    {
        PotatoBucket.text = count + " ";
        UpdateEscapeStatus();
    }

    public void UpdateEscapeStatus()
    {
        if(GameObject.FindGameObjectsWithTag("Bucket").Length == 0)
        {
            isEscape = true;
        } 
    }
    public void PickUp_Bucket()
    {
        count = count + 5; 
    }
}
