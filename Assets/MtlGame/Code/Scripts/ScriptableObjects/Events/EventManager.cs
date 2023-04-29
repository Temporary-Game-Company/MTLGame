using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
public class NewBehaviourScript : MonoBehaviour
{
    private float infectionRate=120f;
    public Home home1;
    public Home home2;
    public Home home3;
    public Home home4;
    public Home home5;
    public Home home6;
    List<Home> unInfectedHomes;
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
        if (!home1.isInfected()&&home1.isAlive())
        {
            unInfectedHomes.Add(home1);
        }

        if (!home2.isInfected()&&home2.isAlive())
        {
            unInfectedHomes.Add(home2);
        }

        if (!home3.isInfected()&&home3.isAlive())
        {
            unInfectedHomes.Add(home3);
        }

        if (!home4.isInfected()&&home4.isAlive())
        {
            unInfectedHomes.Add(home4);
        }

        if (!home5.isInfected()&&home5.isAlive())
        {
            unInfectedHomes.Add(home5);
        }

        if (!home6.isInfected()&&home6.isAlive())
        {
            unInfectedHomes.Add(home6);
        }
    }
}
