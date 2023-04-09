using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmove : MonoBehaviour
{
  /*  [SerializeField] GameObject background;*/
    [SerializeField] GameObject firsttargetobject;
    [SerializeField] GameObject secondtargetobject;
    public Vector3 targetpos;
    backgroundinstantiate mybackgroundinstantiate;
    // Start is called before the first frame update
    void Start()
    {
        targetpos = firsttargetobject.transform.position;
        mybackgroundinstantiate = FindObjectOfType<backgroundinstantiate>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x==targetpos.x)
        {
            if(targetpos!=new Vector3(secondtargetobject.transform.position.x, transform.position.y,transform.position.z))
            {
                
                targetpos = new Vector3(secondtargetobject.transform.position.x, transform.position.y, transform.position.z);
                mybackgroundinstantiate.isinstantiate = true;


            }
            else
            {
                Destroy(gameObject);
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetpos.x, transform.position.y, transform.position.z), 2 * Time.deltaTime);
    }
}
