using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beesmovement : MonoBehaviour
{
    public Rigidbody2D beesrigidbody;
    [SerializeField] Transform leftpos;
    [SerializeField] Transform rightpos;
    Vector2 targetpos;
    Vector2 lefttarget;
    Vector2 righttarget;
    public float xvelocity;
    [SerializeField] GameObject player;
    public bool keepmoving = true;
    public Vector2 playerpos;
    public Vector2 beepreviouspos;
    bool moveback= false;
    public bool reached = false;
    public float yvalue;
    public float frequency = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        lefttarget = new Vector2(leftpos.position.x, transform.position.y);
        righttarget = new Vector2(rightpos.position.x, transform.position.y);
        targetpos = righttarget;
        yvalue = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepmoving)
        {

            //yvalue = Mathf.Sin(2 * Mathf.PI * Time.time * frequency);
            //float yfinal = transform.position.y + yvalue;
            transform.position = Vector2.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
            //transform.position = new Vector2(transform.position.x, yfinal);
            if (new Vector2(transform.position.x, transform.position.y).x == targetpos.x)
            {
                if (targetpos == lefttarget)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    targetpos = righttarget;
                }
                else if (targetpos == righttarget)
                {
                    
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    targetpos = lefttarget;
                }

            }
        }
        if((Mathf.Abs(player.transform.position.x-gameObject.transform.position.x)<4f) && !moveback)
        {
            keepmoving = false;
            reached = false;
            if (playerpos == Vector2.zero)
            {
                beepreviouspos = transform.position;
                playerpos = player.transform.position;
            }
            

        }
        if(playerpos!=Vector2.zero && !reached)
        {
            
            transform.position = Vector3.MoveTowards(transform.position,playerpos,Time.deltaTime*3f);
            if(playerpos==new Vector2(transform.position.x, transform.position.y))
            {
                moveback = true;
                reached = true;
            }
        }
        if(moveback)
        {
            transform.position = Vector3.MoveTowards(transform.position, beepreviouspos, Time.deltaTime * 3f);
            
            if(new Vector2(transform.position.x, transform.position.y) == beepreviouspos)
            {
                playerpos = Vector2.zero;
                moveback = false;
                keepmoving = true;
            }
        }


       
    }

    //IEnumerator hittarget()
    //{
    //    yield return new WaitForSeconds(0.3f);
    //   transform.position = Vector3.MoveTowards(transform.position, playerpos,Time.deltaTime*2f);
    //}
}
