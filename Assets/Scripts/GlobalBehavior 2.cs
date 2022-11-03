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
    void Start()
    {
        GlobalBehavior.GlobalBehaviorInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        PotatoBucket.text = "Potato Collected: " + count + " ";
    }

    public void PickUp_Bucket()
    {
        ++count; 
    }
}
