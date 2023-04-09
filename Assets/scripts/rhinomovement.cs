using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhinomovement : MonoBehaviour
{
    public Rigidbody2D rhinorigidbody;
    [SerializeField] Transform leftpos;
    [SerializeField] Transform rightpos;
    Vector2 targetpos;
    Vector2 lefttarget;
    Vector2 righttarget;
    public float xvelocity;
    
    // Start is called before the first frame update
    void Start()
    {
        lefttarget = new Vector2(leftpos.position.x, transform.position.y);
        righttarget = new Vector2(rightpos.position.x, transform.position.y);
        targetpos = righttarget;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);

        if (new Vector2(transform.position.x, transform.position.y) == targetpos)
        {
            if (targetpos == lefttarget)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                targetpos = righttarget;
            }
            else if(targetpos == righttarget)
            {
                
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                targetpos = lefttarget;
            }

        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.gameObject.GetComponent<Rigidbody2D>().AddForce();
    //}
}
