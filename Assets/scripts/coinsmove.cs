using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsmove : MonoBehaviour
{
    public float movespeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.GetComponent<Rigidbody2D>().velocity = new Vector3(-movespeed, 0f, 0f);
        
        if(transform.position.x<=-7.78f)
        {
            Destroy(gameObject);
        }
    }
}
