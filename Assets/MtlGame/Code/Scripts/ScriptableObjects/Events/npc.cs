using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc : MonoBehaviour
{
    GameObject finalDestination=null;
    private int middleStepPassed=0;
    public bool active=false;
    int[] middleNodes = new int[10];

    // Start is called before the first frame update
    void Start()
    {
        int selectedNode   = Random.Range(1,7); 
        finalDestination = GameObject.Find("node"+selectedNode);
        for (int i = 0; i < 10; i++)
        {
            middleNodes[i]= Random.Range(1,36);
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if(active){
            if(middleStepPassed<9){
                GameObject mDestination=GameObject.Find("g"+middleNodes[middleStepPassed]);
                transform.position = Vector2.MoveTowards(transform.position,mDestination.transform.position,4f*Time.deltaTime);
                float distance = Vector3.Distance (transform.position, mDestination.transform.position);
                if(distance<2f){
                    middleStepPassed=middleStepPassed+1;
                }

            }else if (finalDestination!=null)
            {
            transform.position = Vector2.MoveTowards(transform.position,finalDestination.transform.position,4f*Time.deltaTime);
             float distance = Vector3.Distance (transform.position, finalDestination.transform.position);
                if(distance<2f){
                    Destroy(gameObject);
                }
            }
        }
       
    }
}