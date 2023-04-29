using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    private float infectionRate=120f;

    [SerializeField] List<Home> homes;
    List<Home> unInfectedHomes = new List<Home>();
    public TMP_Text gameTimerText;
    private float gameTimer=0f;
   
    // Start is called before the first frame update
    void Start()
    {
        unInfectedHomes = new List<Home>();
    }

    // Update is called once per frame
    void Update()
    {
        infectHouseRandomly();
        Timer();
    }

    void Timer(){
        gameTimer += Time.deltaTime*1;
         int seconds = (int)(gameTimer % 60);
         int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer /3600) % 24;
        string timeString = string.Format("{0:0}:{1:00}:{2:00}",hours,minutes,seconds);
        gameTimerText.text = timeString;
    }

    void infectHouseRandomly(){
        infectionRate -=1*Time.deltaTime;
        if(infectionRate<0){
            checkUnInfectedHomes();
            int numberOfavailableHomes = unInfectedHomes.Count;
            int selectedHome   = Random.Range(0,numberOfavailableHomes); 
            unInfectedHomes[selectedHome].infectHome();
            infectionRate = 120f;
        }
    }

    void checkUnInfectedHomes(){
         unInfectedHomes = new List<Home>();

         foreach (var home in homes)
        {
            if (!home.isInfected()&&home.isAlive())
            {
               unInfectedHomes.Add(home);
            }
        }
       
    }
}
