using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragonmovement : MonoBehaviour
{
    public Rigidbody2D dragonrigidbody;
    [SerializeField] Transform leftpos;
    [SerializeField] Transform rightpos;
    Vector2 targetpos;
    Vector2 lefttarget;
    Vector2 righttarget;
    public float xvelocity;
    public Transform firepos;
    public GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        lefttarget = new Vector2(leftpos.position.x, transform.position.y);
        righttarget = new Vector2(rightpos.position.x, transform.position.y);
        targetpos = lefttarget;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetpos, Time.deltaTime * 2f);
       
        if (new Vector2(transform.position.x, transform.position.y) == targetpos)
        {
            if (targetpos == lefttarget)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                targetpos = righttarget;
            }
            else
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                targetpos = lefttarget;
            }

        }
    }
    public void instantitatefire()
    {
        GameObject instantiatedfireball = Instantiate(fireball, firepos.transform.position,Quaternion.identity);
        instantiatedfireball.GetComponent<Rigidbody2D>().AddForce(firepos.transform.up * 200f);
    }

}
