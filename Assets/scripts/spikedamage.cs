using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikedamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void ontriggerene(Collision2D collision)
    //{
        
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(30f, 30f));
    }
}
