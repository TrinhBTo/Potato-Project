using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Includes not only move but player behavior in general
public class move : MonoBehaviour
{   
    #region hero_movement_variables
    public float degreesPerSecond = 45.0f;
    public bool mouse = false;
    public float speed = 3f;
    #endregion


    #region bullet_config

    private GameObject bullet = null;
    private Transform firePoint;
    private float bulletSpeed = 4f;
    private float nextFire = 0f;
    private float cooldown = 0.2f;
    #endregion
    
    void Start()
    {
        //Vector3 temp = new Vector3(transform.position.x, transform.position.y, -2f);
        //Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        //temp.z = -2f;
        firePoint = transform;
        bullet = Resources.Load<GameObject>("Prefabs/PotatoSprout");
        Debug.Assert(bullet != null);
    }

    void Update()
    {   
        #region movement
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
        #endregion


        if ((Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            fire();
        }
    }
        
    private void fire()
    {       
        GameObject bullet_instance = Instantiate(bullet, firePoint.position, firePoint.rotation);
        bullet_instance.transform.position = new Vector3(bullet_instance.transform.position.x, bullet_instance.transform.position.y, -2f);
        Rigidbody2D re = bullet_instance.GetComponent<Rigidbody2D>();
        re.velocity = firePoint.up * bulletSpeed;
        nextFire = Time.time + cooldown;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bucket")
        {
            Debug.Log("test");
            Destroy(collision.gameObject);
            GlobalBehavior.GlobalBehaviorInstance.PickUp_Bucket();
        }
    }

}

