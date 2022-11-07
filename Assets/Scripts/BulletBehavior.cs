using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -5 || gameObject.transform.position.x > 7 || gameObject.transform.position.x < -10 )
        {
            Destroy(gameObject);
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        //if((gameObject.transform.position.x > 7 || gameObject.transform.position.x < -10 ||
        //gameObject.transform.position.y > 3 || gameObject.transform.position.y < -5) || 
        //(collision.gameObject.tag == "Islands"))
        if(collision.gameObject.tag == "Islands")
        {
            Destroy(gameObject);
        }
        
        //Destroy(gameObject);

    }
    
    private void OnBecameInvinsible()
    {
        Destroy(gameObject); 
    }
    
}
