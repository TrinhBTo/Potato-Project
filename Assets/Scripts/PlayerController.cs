using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

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
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
    }








    // #region hero_movement_variables
    // public float degreesPerSecond = 45.0f;
    // public bool mouse = false;
    // public float speed = 3f;

    // public RigidBody2D rb;


    // #endregion


    // #region bullet_config

    // public Transform firePoint;
    // public Vector2 lookDirection;
    // public float lookAngle;
    
    // private GameObject bullet = null;
    // private float bulletSpeed = 4f;
    // private float nextFire = 0f;
    // public float cooldown = 0.5f;

    // #endregion



    // // Animation
    // private Animator animator;
    // private SpriteRenderer spriteRenderer;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     bullet = Resources.Load<GameObject>("Prefabs/PotatoSprout");
    //     Debug.Assert(bullet != null);


    //     // // Animation
    //     // animator = GetComponent<Animator>();
    //     // spriteRenderer = GetComponent<SpriteRenderer>();
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     // lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
    //     // firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

    //     Move();
    // }

    // private void Move()
    // {
    //     // Transform coordinates
    //     #region movement

    
    //     Vector3 pos = transform.position;

    //     if (Input.GetKey("w"))
    //     {
    //         pos.y += speed * Time.deltaTime;
    //         // firePoint.eulerAngles = new Vector3(0, 0, 0);
    //     }

    //     if (Input.GetKey("s"))
    //     {
    //         pos.y -= speed * Time.deltaTime;
    //         // firePoint.eulerAngles = new Vector3(0, 0, 180);
    //     }

    //     if (Input.GetKey("d"))
    //     {
    //         pos.x += speed * Time.deltaTime;
    //         // firePoint.eulerAngles = new Vector3(0, 0, 270);
    //     }

    //     if (Input.GetKey("a"))
    //     {
    //         pos.x -= speed * Time.deltaTime;
    //         // firePoint.eulerAngles = new Vector3(0, 0, 90);
    //     }
    //     transform.position = pos;

    //     #endregion


    //     if ((Input.GetKey(KeyCode.Space)) && Time.time > nextFire)
    //     {
    //         fire();
    //     }

    //     // Animation
    //     if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a"))
    //     {
    //         animator.SetBool("Walk", true);
    //     }
    //     else
    //     {
    //         animator.SetBool("Walk", false);
    //     }

    //     // Sprite Flip
    //     if (Input.GetKey("d"))
    //     {
    //         spriteRenderer.flipX = true;
    //     }   
    //     else if (Input.GetKey("a"))
    //     {
    //         spriteRenderer.flipX = false;
    //     }
    // }

    // private void fire()
    // {       

    //     Vector3 bullet_pos = transform.position;
    //     GameObject bullet_instance = Instantiate(bullet, bullet_pos, Quaternion.identity);
    //     bullet_instance.transform.right = transform.right.normalized;
    //     Rigidbody2D re = bullet_instance.GetComponent<Rigidbody2D>();
    //     re.velocity = firePoint.up * bulletSpeed;

    //     nextFire = Time.time + cooldown;

    // }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if(collision.gameObject.tag == "Bucket")
    //     {
    //         Destroy(collision.gameObject);
    //         GlobalBehavior.GlobalBehaviorInstance.PickUp_Bucket();
    //     }

    // }

    // void OnCollisionEnter2D(Collision2D myCollisionInfo)
    // {
    //     if(myCollisionInfo.gameObject.tag == "Human")
    //     {
    //         HealthSystem.MinusLife();
    //     }
    // }
}
