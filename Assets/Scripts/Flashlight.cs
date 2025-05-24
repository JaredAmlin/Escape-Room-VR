using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject _light;

    private void Start()
    {
        if (_light != null)
        {
            _light.SetActive(false);
        }
        else
            Debug.LogWarning("The Light on the Flashlight is NULL");
    }

    public void ToggleLight()
    {
        if (_light.activeInHierarchy)
        {
            _light.SetActive(false);
        }
        else
            _light.SetActive(true);
    }
}
