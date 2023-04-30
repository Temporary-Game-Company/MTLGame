using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.InventoryEngine;

public class Home : MonoBehaviour
{
    [SerializeField] float timeToRescue=100f;
    private bool infectionStatus = false;
    private bool liveStatus = true;
    private float passedTimeForRescue=0f;

    [Tooltip("The list of possible remedies randomly chosen from.")]
    [SerializeField] private ItemSet _possibleRemedies;
    private InventoryItem _remedyNeeded;

    [Tooltip("The inventory to check for the remedy.")]
    [SerializeField] private Inventory _playerInventory;


    [Tooltip("The indicator for when sick.")]
    [SerializeField] private HelpIndicator _helpIndicataor;



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
    }

    public bool isInfected(){
        return infectionStatus;
    }

    public bool isAlive(){
        return liveStatus;
    }

    public void infectHome(){
        infectionStatus = true;
        
        SetRemedy();
        _helpIndicataor.HelpNeeded(_remedyNeeded.Icon);
    }

    public void disinfectHome()
    {
        infectionStatus = false;

        _helpIndicataor.Cured();
    }

    // Sets a random remedy needed 
    private void SetRemedy()
    {
        int randomItem = Random.Range(0, _possibleRemedies.GetItems().Count);
        _remedyNeeded = _possibleRemedies.GetItems()[randomItem];
    }

    public void cure(){
        Debug.Log("Reached");
        InventoryItem playerItem = _playerInventory.Content[0];

        if(playerItem.Equals(_remedyNeeded) && liveStatus && infectionStatus){
            disinfectHome();
        }
    }

}
