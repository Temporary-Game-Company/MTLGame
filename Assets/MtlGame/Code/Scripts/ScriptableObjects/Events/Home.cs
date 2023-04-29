using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] float timeToRescue=100f;
    private bool infectionStatus = false;
    private bool liveStatus = true;
    private float passedTimeForRescue=0f;
    // Start is called before the first frame update
    void Start()
    {
        infectionStatus = false;
        liveStatus = true;
        timeToRescue=100f;
        passedTimeForRescue=0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(liveStatus){
            if (infectionStatus){
            passedTimeForRescue += 1*Time.deltaTime;
            if(timeToRescue<passedTimeForRescue){
                liveStatus = false;
            }
            }else{
            passedTimeForRescue=0f;
            }
        }

        if(infectionStatus){
            Debug.Log("I am "+transform.name+ "and infected");
        }
      
    }

    public bool isInfected(){
        return infectionStatus;
    }

    public bool isAlive(){
        return liveStatus;
    }

    public void infectHome(){
        infectionStatus = true;
    }

    public void cure(){
        if(liveStatus&&infectionStatus){
            infectionStatus=false;
        }
    }

}
