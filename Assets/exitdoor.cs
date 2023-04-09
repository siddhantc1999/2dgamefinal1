using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitdoor : MonoBehaviour
{
    scenemanager myscenemanager;
    // Start is called before the first frame update
    void Start()
    {
        myscenemanager = FindObjectOfType<scenemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            myscenemanager.loadnextscreen();
        }
        
    }
}
