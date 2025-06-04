using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Animator _exitDoorAnimatior;

    [SerializeField] private int _locksUnlocked;

    [SerializeField] private Canvas _screenSpaceCanvas;

    [SerializeField] UnityEvent _onUnlock;

    [SerializeField] UnityEvent _onGameComplete;

    // Start is called before the first frame update
    void Start()
    {
        LightBlade.onRoomComplete += LightBlade_onRoomComplete;

        StartCoroutine(DisableCanvasRoutine());
    }

    private void OnDisable()
    {
        LightBlade.onRoomComplete -= LightBlade_onRoomComplete;
    }

    private void LightBlade_onRoomComplete()
    {
        _onGameComplete.Invoke();
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator DisableCanvasRoutine()
    {
        yield return new WaitForSeconds(8f);

        if (_screenSpaceCanvas != null)
            _screenSpaceCanvas.enabled = false;
    }
}
