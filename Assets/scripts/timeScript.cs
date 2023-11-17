using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timeScript : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public GameObject[] deers = null;
    public GameObject[] foxes = null;
    public GameObject[] bears = null;

    public GameObject dayScreen;

    public TextMeshProUGUI dayCounterText;

    public GameObject player;



    public int deerCount;
    public int foxCount;
    public int bearCount;

    public int dayCount;

    public enemySpawner spawner;


    public healthBar healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TimerOn = true; //this is JUST FOR TESTING, ONLY TURN TIMER ON IF THE PLAYER LEAVES THE HOUSE

        dayCount = 1;

        dayScreen.SetActive(false);



        deers = new GameObject[999];
        bears = new GameObject[999];
        foxes = new GameObject[999];

        //START WITH BASE AMOUNT OF DEERS BELOW
    }

    private void Awake()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else //TIME IS UP
            {
                Debug.Log("TIME IS UP");
                TimeLeft = 0;
                TimerOn = false;


                timeOver(); //this calls the method for dealing with the day change
            }
        }
    }

    public void timerOn()
    {
        TimerOn = true;
    }

    public void timerOff()
    {
        TimerOn = false;
    }

    public void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        string timerText = string.Format("{0:00} : {1:00}", minutes, seconds);
        healthBarScript.updateTimer(timerText);
    }

    public void getEnemyCounts()
    {
        deers = GameObject.FindGameObjectsWithTag("deer");
        foxes = GameObject.FindGameObjectsWithTag("fox");
        bears = GameObject.FindGameObjectsWithTag("bear");

        if (deers != null)
        {
            deerCount = deers.Length;
        }

        if(foxes != null)
        {
            foxCount = foxes.Length;
        }
        
        if(bears != null)
        {
            bearCount = bears.Length;
        }
        

        //START ALGORITHM FOR DETERMINING THE NEXT ROUNDS DEER/FOX/BEAR COUNT(S), GIVEN REMAINING AMOUNT
        //use rand for deciding whether to add a fox or bear, but add 0.daycount    

        deerCount *= 2;
        deerCount += dayCount;

        if(dayCount > 1)//fox spawner
        {
            if(foxCount == 0)
            {
                foxCount += dayCount / 2;
            }
            else
            {
                foxCount *= Random.Range(1, dayCount / 2 + 1);

            }
        }

        if (dayCount > 2)//bear spawner
        {
            if(bearCount == 0) //if there are no current bears
            {
                bearCount += dayCount / 3;
            }
            else //if there are remaining bears
            {
                bearCount *= Random.Range(1, dayCount / 2);
            }
            
        }

        spawner.spawnEnemys(deerCount, foxCount, bearCount); //spawns the enemys on the map


    }

    public void timeOver()
    {
        player.SetActive(false);

        TimeLeft = 120;
        TimerOn = false;

        dayCount += 1;

        dayCounterText.text = dayCount.ToString();
        dayScreen.SetActive(true);

        StartCoroutine(dayScreenWaiter());
        
    }

    IEnumerator dayScreenWaiter()
    {
        yield return new WaitForSeconds(5);

        dayScreen.SetActive(false);


        //switch scene to house
        player.GetComponent<playerStatus>().stopped = true;
        getEnemyCounts(); //this spawns the new enemys
        player.SetActive(true);

        player.GetComponent<playerStatus>().saveValues();

        

        

        SceneManager.LoadScene("house"); //loads player to the house

    }

    public int getDayCount()
    {
        return dayCount;
    }
}
