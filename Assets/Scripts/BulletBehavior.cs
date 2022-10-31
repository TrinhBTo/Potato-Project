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
        
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((gameObject.transform.position.x > 7 || gameObject.transform.position.x < -10 ||
        gameObject.transform.position.y > 3 || gameObject.transform.position.y < -5) || 
        (collision.gameObject.tag == "Islands"))
        {
            Debug.Log("test");
            Destroy(gameObject);
        }

    }
    /*
    private void OnBecameInvinsible()
    {
        Destroy(gameObject); 
    }
    */
}
