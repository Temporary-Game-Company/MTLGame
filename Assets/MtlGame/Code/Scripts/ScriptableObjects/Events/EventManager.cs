using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
public class EventManager : MonoBehaviour
{
    [SerializeField] private float _timeToFirstInfection = 5f;
    [SerializeField] private float infectionRate = 120f;

    private float _timeToInfection;

    [SerializeField] List<Home> homes;
    List<Home> unInfectedHomes = new List<Home>();
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
    }

    void infectHouseRandomly(){
        _timeToInfection -=1*Time.deltaTime;
        if(_timeToInfection<0){
            checkUnInfectedHomes();
            int numberOfavailableHomes = unInfectedHomes.Count;
            int selectedHome   = Random.Range(0,numberOfavailableHomes); 
            unInfectedHomes[selectedHome].infectHome();
            _timeToInfection = infectionRate;
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
