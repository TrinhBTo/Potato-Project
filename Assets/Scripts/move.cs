using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Includes not only move but player behavior in general
public class move : MonoBehaviour
{   
    public Rigidbody2D rb;
    public Vector2 movement;
    public float moveSpeed;
    public Animator animator;


    #region bullet_config

    private GameObject bullet = null;
    private Transform firePoint;
    private float bulletSpeed = 4f;
    private float nextFire = 0f;
    private float cooldown = 0.5f;
    #endregion
    
    void Start()
    {
        //Vector3 temp = new Vector3(transform.position.x, transform.position.y, -2f);
        //Vector2 temp = new Vector2(transform.position.x, transform.position.y);
        //temp.z = -2f;
        //firePoint = transform;
        bullet = Resources.Load<GameObject>("Prefabs/PotatoSprout");
        Debug.Assert(bullet != null);
    }

    void Update()
    {   
        // Handle Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x); 
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal")); 
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if ((Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
        {
            fire();
        }
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }

    private void fire()
    {       
        //Get the Screen positions of the object
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint (transform.position);         
        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Get the angle between the points
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        Vector2 temp = mouseOnScreen - positionOnScreen;
        GameObject bullet_instance = Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0f,0f,angle + 90)));
        bullet_instance.transform.position = new Vector3(bullet_instance.transform.position.x, bullet_instance.transform.position.y, -2f);
        
        Rigidbody2D re = bullet_instance.GetComponent<Rigidbody2D>();
        re.velocity = bullet_instance.transform.up * bulletSpeed;
        nextFire = Time.time + cooldown;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bucket")
        {
            Destroy(collision.gameObject);
            GlobalBehavior.GlobalBehaviorInstance.PickUp_Bucket();
        }

    }
    void OnCollisionEnter2D(Collision2D myCollisionInfo)
    {
            if(myCollisionInfo.gameObject.tag == "Human")
        {
            HealthSystem.MinusLife();
        }
    }
}

