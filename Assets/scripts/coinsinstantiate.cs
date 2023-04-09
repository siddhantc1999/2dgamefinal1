using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class coinsinstantiate : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] GameObject coins;
    public List<Transform> waypoints;
    bool isinstatntiating = true;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = new List<Transform>();
        Debug.Log(transform.childCount);
       
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoints.Add(transform.GetChild(i).transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            int num = Random.Range(0, transform.childCount-1);
            Instantiatecoin(transform.GetChild(num).transform);
        }
    }

    public void Instantiatecoin(Transform pos)
    {
        
        if(isinstatntiating)
        {
            isinstatntiating = false;
            GameObject coin = Instantiate(coins,pos.position,Quaternion.identity);
            coin.transform.parent = parent.transform;
            StartCoroutine(Instantiatewithdelay());
        }
    }

IEnumerator Instantiatewithdelay()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));
        isinstatntiating = true;
    }
}
