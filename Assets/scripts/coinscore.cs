using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinscore : MonoBehaviour
{
   
    public int coins=0;
    totalscore mytotalscore;
    // Start is called before the first frame update
    void Start()
    {
        mytotalscore = FindObjectOfType<totalscore>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name=="player")
        {
            mytotalscore.coins+=1;

            mytotalscore.publishscore();

            Destroy(gameObject);
        }
        
    }
}
