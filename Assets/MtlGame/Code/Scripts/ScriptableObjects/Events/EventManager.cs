using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using UnityEngine.UI;
using TMPro;
using MoreMountains.TopDownEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] LevelSelector _selector;
    [SerializeField] private float _timeToFirstInfection = 5f;
    [SerializeField] private float infectionRate = 120f;

    [SerializeField] private float _npcSpawnTime;

    private float _timeToInfection;

    [SerializeField] List<Home> homes;
    [SerializeField] List<GameObject> npcs;

    List<Home> unInfectedHomes = new List<Home>();
    public TMP_Text gameTimerText;
    private float gameTimer=0f;
    private float npcGeneration=0f;
    // Start is called before the first frame update
    void Start()
    {
        unInfectedHomes = new List<Home>();

        _timeToInfection = _timeToFirstInfection;
    }

    // Update is called once per frame
    void Update()
    {
        infectHouseRandomly();
        Timer();
        npcGeneration += Time.deltaTime*1;
        if(_npcSpawnTime<npcGeneration){
            createNPC();
            npcGeneration = 0f;
        }
      //    Debug.Log("AAAAAA");
       
    }

    void Timer(){
        gameTimer += Time.deltaTime*1;
         int seconds = (int)(gameTimer % 60);
         int minutes = (int)(gameTimer / 60) % 60;
        int hours = (int)(gameTimer /3600) % 24;
        string timeString = string.Format("{0:0}:{1:00}:{2:00}",hours,minutes,seconds);
        gameTimerText.text = timeString;
    }

    void createNPC(){
        int npcType = Random.Range(0,npcs.Count); 
        GameObject selectedNpc = npcs[npcType];
        int selectedNode   = Random.Range(1,homes.Count-1); 
        Debug.Log(selectedNode);
        GameObject startNode = GameObject.Find("node"+selectedNode);
        GameObject pc = Instantiate(selectedNpc,startNode.transform.position,selectedNpc.transform.rotation) as GameObject;
        pc.GetComponent<npc>().active=true;
    }

    void infectHouseRandomly(){
        _timeToInfection -=1*Time.deltaTime;
        if(_timeToInfection<0){
            checkUnInfectedHomes();
            int numberOfavailableHomes = unInfectedHomes.Count;
            int selectedHome   = Random.Range(0,numberOfavailableHomes); 

            if (numberOfavailableHomes > 0) unInfectedHomes[selectedHome].infectHome();
            _timeToInfection = infectionRate;
        }
    }

    void checkUnInfectedHomes(){
         unInfectedHomes = new List<Home>();
        List<Home> aliveOnes = new List<Home>();

         foreach (var home in homes)
        {
            if (!home.isInfected()&&home.isAlive())
            {
               unInfectedHomes.Add(home);
            }
            if (home.isAlive()) aliveOnes.Add(home);
        }
       if (aliveOnes.Count == 0) Lose();
    }

    private void Lose()
    {
        _selector.GoToLevel();
    }
}
