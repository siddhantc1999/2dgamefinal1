using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class springtrigger : MonoBehaviour
{
    Animator myanimator;
    bool addforce = true;
    public Vector3 direction;
    public float magnitude;
    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        if(addforce)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Animator>().SetTrigger("jump"); 
        myanimator.SetTrigger("springed");
        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log("the player name "+ collision.gameObject.name);
        rigidbody.AddForce(direction * magnitude);
       
    }
}
