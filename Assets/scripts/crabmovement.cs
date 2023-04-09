using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crabmovement : MonoBehaviour
{
    public float xmovement=1f;
    bool right = true;
    public Transform leftpos;
    public Transform rightpos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject fireball;
    Animator myanimator;
    AnimatorClipInfo[] myanimatorclipinfo;
    bool fireinstantiate;
    bool keepinstantiating=true;
    public bool iscolliding;
    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(0);
       
       
        if (myanimatorclipinfo[0].clip.name == "crabrun")
        {
          
            transform.GetComponent<Rigidbody2D>().velocity = new Vector3(-xmovement * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (Mathf.Abs((player.transform.position.x) - (gameObject.transform.position.x))<5f)
        {

            fireinstantiate = true;
            myanimator.SetBool("attack",true);
           

        }
        else
        {
            fireinstantiate = false;
            myanimator.SetBool("attack", false);
        }
        //to instantiate fireball in the game
        if(fireinstantiate && keepinstantiating)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (iscolliding)
            return;
        else
            iscolliding = true;
        if (iscolliding)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("landarea"))
            {
                //Debug.Log(transform.localScale);
                if (transform.localScale.x > 0)
                {


                    transform.localScale = new Vector3(-1f, 1f, 1f);
                    crabmove();
                }
                else if (transform.localScale.x < 0)
                {


                    transform.localScale = new Vector3(1f, 1f, 1f);
                    crabmove();
                }
            }
        }
        StartCoroutine(Reset());
      /*  StartCoroutine(Reset());*/
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2f);
        iscolliding = false;
    }

    /* private void OnTriggerExit2D(Collider2D collision)
{
  *//*  if (!iscolliding)
        return;*//*
    iscolliding = false;
}
*/
    public void crabmove()
    {
        
    xmovement = -xmovement;
        
        
    }

}
