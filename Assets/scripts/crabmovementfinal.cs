using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crabmovementfinal : MonoBehaviour
{
    public float xmovement = 1f;
    bool right = true;
    public Transform leftpos;
    public Transform rightpos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fireball;
    Animator myanimator;
    AnimatorClipInfo[] myanimatorclipinfo;
    bool fireinstantiate;
    bool keepinstantiating = true;
    public bool iscolliding;


    [SerializeField] Transform lefttargetposition;
    [SerializeField] Transform righttargetposition;
    Vector2 targetpos;
    Vector2 lefttarget;
    Vector2 righttarget;
    // Start is called before the first frame update
    void Start()
    {
        lefttarget = lefttargetposition.position;
        righttarget = righttargetposition.position;
        myanimator = GetComponent<Animator>();
        targetpos = lefttarget;

    }

    // Update is called once per frame
    void Update()
    {
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(0);


        if (myanimatorclipinfo[0].clip.name == "crabrun")
        {

            transform.position = Vector2.MoveTowards(transform.position, targetpos, Time.deltaTime );

            if (new Vector2(transform.position.x, transform.position.y) == targetpos)
            {
                if (targetpos == lefttarget)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    targetpos = righttarget;
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    targetpos = lefttarget;
                }

            }
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (Mathf.Abs((player.transform.position.x) - (gameObject.transform.position.x)) < 3f)
        {

            fireinstantiate = true;
            myanimator.SetBool("attack", true);


        }
        else
        {
            fireinstantiate = false;
            myanimator.SetBool("attack", false);
        }
        //to instantiate fireball in the game
        if (fireinstantiate && keepinstantiating)
        {
            keepinstantiating = false;
            StartCoroutine(Instantiatewithdelay());
        }
    }

    /*public void instantiatefireball()
    {
        StartCoroutine(Instantiatewithdelay());
        
    }*/

    public IEnumerator Instantiatewithdelay()
    {
        if (transform.localScale.x > 0f)
        {
            GameObject leftfireball = Instantiate(fireball, leftpos.transform.position, Quaternion.identity);
            leftfireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 0f));
            GameObject righttfireball = Instantiate(fireball, rightpos.transform.position, Quaternion.identity);
            righttfireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 0f));
        }
        else
        {
            GameObject leftfireball = Instantiate(fireball, leftpos.transform.position, Quaternion.identity);
            leftfireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(200f, 0f));
            GameObject righttfireball = Instantiate(fireball, rightpos.transform.position, Quaternion.identity);
            righttfireball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 0f));
        }
        yield return new WaitForSeconds(3f);
        keepinstantiating = true;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (iscolliding)
    //        return;
    //    else
    //        iscolliding = true;
    //    if (iscolliding)
    //    {
    //        if (collision.gameObject.layer == LayerMask.NameToLayer("landarea"))
    //        {
    //            //Debug.Log(transform.localScale);
    //            if (transform.localScale.x > 0)
    //            {


    //                transform.localScale = new Vector3(-1f, 1f, 1f);
    //                crabmove();
    //            }
    //            else if (transform.localScale.x < 0)
    //            {


    //                transform.localScale = new Vector3(1f, 1f, 1f);
    //                crabmove();
    //            }
    //        }
    //    }
    //    StartCoroutine(Reset());
    //    /*  StartCoroutine(Reset());*/
    //}

    //IEnumerator Reset()
    //{
    //    yield return new WaitForSeconds(2f);
    //    iscolliding = false;
    //}

  
    //public void crabmove()
    //{

    //    xmovement = -xmovement;


    //}

}