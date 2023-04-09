using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class totalscore : MonoBehaviour
{
    public int coins = 0;
    public int lives = 3;
    [SerializeField] GameObject mytext;
    TextMeshProUGUI socertext;
    // Start is called before the first frame update
    void Start()
    {
        mytext = GameObject.Find("score");
        socertext = mytext.GetComponent<TextMeshProUGUI>();
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void publishscore()
    {
        socertext.text = "SCORE: " + coins.ToString();
    }
}
