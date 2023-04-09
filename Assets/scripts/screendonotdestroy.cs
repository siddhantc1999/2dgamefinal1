using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screendonotdestroy : MonoBehaviour
{
    public int screencount;
    private void Awake()
    {
        screencount = FindObjectsOfType<screendonotdestroy>().Length;
        if (screencount == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
