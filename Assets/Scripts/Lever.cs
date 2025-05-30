using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool _isActivated = false;

    [SerializeField] UnityEvent _onActivateLever;
    [SerializeField] UnityEvent _onDeactivateLever;

    public void LeverTrigger()
    {
        if(_isActivated)
        {
            _isActivated = false;

            //handle lever deactivation
            _onDeactivateLever.Invoke();
        }
        else
        {
            _isActivated = true;

            //handle lever activation
            _onActivateLever.Invoke();
        }
    }
}
