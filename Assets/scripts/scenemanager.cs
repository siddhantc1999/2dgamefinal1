using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public bool isstart;
    [SerializeField] GameObject playbutton;
    int currentindex;
    int totalscreens;
    public int currentlives;
    [SerializeField] GameObject gameoverscreen;
    [SerializeField] GameObject gamesucecsscreen;

    //public int lives = 3;
    //[SerializeField] GameObject mylives;
    //TextMeshProUGUI livestext;

    // Start is called before the first frame update
    public int lives;
    bool isloaded = false;
    void Start()
    {
        totalscreens = SceneManager.sceneCountInBuildSettings;
        
        DontDestroyOnLoad(gameObject);
        isstart = false;
        
     


    }

    // Update is called once per frame
    void Update()
    {
        if(currentlives<=0)
        {
            gameoverscreen.active = true;
            Destroy(FindObjectOfType<playermove>().gameObject);
            isstart = false;
        }

        if (isloaded)
        {

            GameObject player = GameObject.Find("player");
            if (player != null)
            {
                FindObjectOfType<playermove>().lives = 3;
                Debug.Log(FindObjectOfType<playermove>());
                Debug.Log(FindObjectOfType<playermove>().lives);
                FindObjectOfType<playermove>().livesprint();
                gameoverscreen.active =false;
                gamesucecsscreen.active = false;
            }
            else
            {
                Debug.Log("here");
            }
            isloaded = false;
        }
    }
    public void startrunning()
    {
        isstart = true;
        playbutton.gameObject.active = false;
    }

    public void stoprunning()
    {
        isstart = false;
        playbutton.gameObject.active = true;
    }
    public void loadnextscreen()
    {
       
       
       currentindex = SceneManager.GetActiveScene().buildIndex;
        if (currentindex== totalscreens-1)
        {
            SceneManager.LoadScene(0);

        }
        else
        {
            SceneManager.LoadScene(currentindex+1);
            

        }
    }
    public void loadstartscreen()
    {
        SceneManager.LoadScene(0);
        
        FindObjectOfType<totalscore>().coins = 0;
        FindObjectOfType<totalscore>().publishscore();
        isloaded = true;
        playbutton.active = true;
        //isstart = false;

    }
    public void successscreen()
    {
        gamesucecsscreen.active = true;
    }



}
