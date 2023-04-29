using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProneToSickness : MonoBehaviour
{
    protected bool _isInfected = false;

    public UnityEvent OnInfect;

    public UnityEvent OnCure;
    
    public void Infect()
    {
        if (!_isInfected)
        {
            _isInfected = true;
            OnInfect.Invoke();
        }
        
    }

    public void Cure()
    {
        if (_isInfected)
        {
            _isInfected = false;
            OnCure.Invoke();
        }
    }
}
