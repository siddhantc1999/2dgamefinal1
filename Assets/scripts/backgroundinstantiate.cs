using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundinstantiate : MonoBehaviour
{
    public bool isinstantiate;
    [SerializeField] GameObject instantiatepos;
    [SerializeField] GameObject instantiategameobject;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isinstantiate)
        {
            isinstantiate = false;
            GameObject newgameobject = Instantiate(instantiategameobject,instantiatepos.transform.position,Quaternion.identity);
           
        }
    }
}
