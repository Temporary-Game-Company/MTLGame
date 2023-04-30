using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameOver;
using MoreMountains.InventoryEngine;
using MoreMountains.Feedbacks;
using UnityEngine.UI;


public class Home : MonoBehaviour
{
    private bool infectionStatus = false;
    private bool liveStatus = true;
    public Slider healthBarSlider;


    [Tooltip("Time before a sick person dies.")]
    [SerializeField] private float _timeToRescue = 0f;
    private float _timeLeftToRescue;

    [Tooltip("The list of possible remedies randomly chosen from.")]
    [SerializeField] private ItemSet _possibleRemedies;
    private InventoryItem _remedyNeeded;

    [Tooltip("The inventory to check for the remedy.")]
    [SerializeField] private Inventory _playerInventory;


    [Tooltip("The indicator for when sick.")]
    [SerializeField] private HelpIndicator _helpIndicataor;

    [SerializeField] private MMFeedback _curedFeedback;


    [Tooltip("The sprite for when dead.")]
    [SerializeField] private Sprite _deadSprite;

    // Start is called before the first frame update
    void Start()
    {
        infectionStatus = false;
        liveStatus = true;
        _timeLeftToRescue=_timeToRescue;
    }

    // Update is called once per frame
    void Update()
    {
        if(liveStatus){
            if (infectionStatus) {
                _timeLeftToRescue -= 1*Time.deltaTime;
                
                if(_timeLeftToRescue<=0f){
                    Die();
                    _timeLeftToRescue=_timeToRescue;
                }
                
                // Update the health bar slider based on the current _timeLeftToRescue
                healthBarSlider.value = _timeLeftToRescue / _timeToRescue;
            }
            else {
                _timeLeftToRescue=_timeToRescue;
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

    private void Die()
    {
        liveStatus = false;
        GameOver.nbHouseDie += 1;
        _helpIndicataor.HelpNeeded(_deadSprite);
    }

    // Feedback and internal for when home is cured.
    public void disinfectHome()
    {
        infectionStatus = false;

        _helpIndicataor.Cured();
        _curedFeedback.Play(transform.position);
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

        if(playerItem.ItemID.Equals(_remedyNeeded.ItemID) && liveStatus && infectionStatus){
            disinfectHome();
        }
    }

}
