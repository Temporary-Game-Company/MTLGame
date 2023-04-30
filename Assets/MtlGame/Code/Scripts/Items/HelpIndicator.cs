using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpIndicator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bubbleRenderer;
    [SerializeField] private SpriteRenderer _remedyRenderer;

    // Disable sprites.
    private void Start()
    {
        _bubbleRenderer.enabled = false;
        _remedyRenderer.enabled = false;
    }

    // Enable sprites and set remedy sprite.
    // **todo** play sound.
    public void HelpNeeded(Sprite sprite)
    {
        _bubbleRenderer.enabled = true;
        _remedyRenderer.enabled = true;
        _remedyRenderer.sprite = sprite;
    }

    // To be called when no longer need help. Disables sprites. 
    // **todo** play sound.
    public void Cured()
    {
        _bubbleRenderer.enabled = false;
        _remedyRenderer.enabled = false;
    }
}
