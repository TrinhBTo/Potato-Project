using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    float dirX, dirY, moveSpeed;

    // public Transform target;
    public SpriteRenderer spriteRenderer;
    public GameObject Ordinary;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = Ordinary.GetComponent<Animator>();
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 direction = (target.position - transform.position).normalized; 
        // spriteRenderer.flipX = direction.x < 0;
        // transform.position += direction * moveSpeed * Time.deltaTime;

        if(Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("w"))
        {
        }
        else{
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
            dirY = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x + dirX, transform.position.y + dirY);
        }


        if (dirX != 0)
        {

            if (dirX < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            anim.SetInteger("Animate", 2); // walk
        }
        else
        {
            anim.SetInteger("Animate", 0); // idle
        }

    }
}
