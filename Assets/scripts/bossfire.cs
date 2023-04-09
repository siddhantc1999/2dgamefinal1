using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossfire : MonoBehaviour
{
    public int bosshelath=10;
    [SerializeField] GameObject firstfire;
    [SerializeField] GameObject finalfire;
    public bool keepfire=false;
    scenemanager myscenemanager;
    // Start is called before the first frame update
    void Start()
    {

      


    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        myscenemanager = FindObjectOfType<scenemanager>();
        if (bosshelath==0)
        {
            GameObject firstfiregameobject = Instantiate(finalfire, transform.position, Quaternion.identity);
            myscenemanager.successscreen();

            Destroy(transform.parent.gameObject, 1f);

           
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bosshelath>0)
        {
            if (!keepfire)
            {
                GameObject firstfiregameobject = Instantiate(firstfire, transform.position, Quaternion.identity);
                bosshelath -= 1;
                keepfire = true;
            }
        }
        //else if(bosshelath==0)
        //{
           
        //    GameObject firstfiregameobject = Instantiate(finalfire, transform.position, Quaternion.identity);
          
        //    Debug.Log("hrer");
        //    Destroy(transform.parent.gameObject, 1f);
            

        //}
            
    }
}
