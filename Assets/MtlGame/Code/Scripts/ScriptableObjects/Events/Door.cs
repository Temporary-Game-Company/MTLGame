using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Home home;
    private bool playerIsNearDoor=false;

    void OnTriggerExit2D(Collider2D other)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerIsNearDoor=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
