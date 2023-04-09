using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class failscreen : MonoBehaviour
{
    [SerializeField]playermove myplayermove;
    scenemanager myscenemanager;
    [SerializeField] GameObject thefailscreen;
    public int currentlives;
    // Start is called before the first frame update
    void Start()
    {
        
        myscenemanager = FindObjectOfType<scenemanager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(myplayermove.lives);
        currentlives = myplayermove.lives;
        if (myplayermove.lives<=0 )
        {

            Debug.Log("here in failed");
            thefailscreen.active = true;
            myscenemanager.isstart = false;
        }
    }
}
