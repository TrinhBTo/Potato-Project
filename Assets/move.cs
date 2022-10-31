using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{   

    public float degreesPerSecond = 45.0f;
    public bool mouse = true;
    public float speed = 3f;

   
    
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.M))
        {
            mouse = !mouse;
        }
        Vector3 mousePosition = transform.position;

        if (mouse)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;

        }
        else {
    
        Vector3 pos = transform.position;

        // "w" can be replaced with any key
        // this section moves the character up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        // "s" can be replaced with any key
        // this section moves the character down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }


        // "q" can be replaced with any key
        // this section moves the character left
        double v = 0.707;
        float diagonal = (float)v;

        if (Input.GetKey("q"))
        {
            pos.x -= diagonal * speed * Time.deltaTime;
            pos.y += diagonal * speed * Time.deltaTime;
        }

        // "e" can be replaced with any key
        // this section moves the character left
     
        if (Input.GetKey("e"))
        {
            pos.x += diagonal * speed * Time.deltaTime;
            pos.y += diagonal * speed * Time.deltaTime;
        }

        // "z" can be replaced with any key
        // this section moves the character left

        if (Input.GetKey("z"))
        {
            pos.x -= diagonal * speed * Time.deltaTime;
            pos.y -= diagonal * speed * Time.deltaTime;
        }

        // "c" can be replaced with any key
        // this section moves the character left

        if (Input.GetKey("c"))
        {
            pos.x += diagonal * speed * Time.deltaTime;
            pos.y -= diagonal * speed * Time.deltaTime;
        }
        transform.position = pos;
        }

    }
        
}

