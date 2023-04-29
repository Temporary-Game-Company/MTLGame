using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
public class NewBehaviourScript : MonoBehaviour
{
    private float infectionRate=120f;

    [SerializeField] List<Home> homes;
    List<Home> unInfectedHomes = new List<Home>();
    // Start is called before the first frame update
    void Start()
    {
        unInfectedHomes = new List<Home>();
    }

    // Update is called once per frame
    void Update()
    {
        infectHouseRandomly();
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
