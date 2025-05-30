using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator _exitDoorAnimatior;

    [SerializeField] private int _locksUnlocked;

    [SerializeField] UnityEvent _onUnlock;

    // Start is called before the first frame update
    void Start()
    {
        LightBlade.onRoomComplete += LightBlade_onRoomComplete;
    }

    private void OnDisable()
    {
        LightBlade.onRoomComplete -= LightBlade_onRoomComplete;
    }

    private void LightBlade_onRoomComplete()
    {
        OnGameComplete();
    }

    private void OnGameComplete()
    {
        if(_exitDoorAnimatior != null)
            _exitDoorAnimatior.SetTrigger("OpenDoor");
    }

    public void Unlock()
    {
        _locksUnlocked++;

        if (_locksUnlocked >= 2)
        {
            //activate secret box
            _onUnlock.Invoke();
        }
    }
}
