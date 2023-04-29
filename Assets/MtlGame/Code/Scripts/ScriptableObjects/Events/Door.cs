using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Home home;
    private bool playerIsNearDoor=false;

    void OnTriggerEnter2D(Collider2D other)
    {
         playerIsNearDoor=true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
         playerIsNearDoor=false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerIsNearDoor=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsNearDoor&&Input.GetKey(KeyCode.F)){
            // Check if ingridient is correct
            // then call cure function
            home.cure();
        }
    }
}
