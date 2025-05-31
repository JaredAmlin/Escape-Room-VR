using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightBlade : MonoBehaviour
{
    [SerializeField] private ParticleSystem _lightParticles;

    public static event Action onRoomComplete;

    private void OnTriggerStay(Collider other)
    {
        if (_lightParticles != null)
        {
            if (!_lightParticles.isPlaying)
            {
                _lightParticles.Play();
                //_lightParticles.transform.position = other.ClosestPoint(_lightParticles.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_lightParticles != null)
            _lightParticles.Stop();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chains"))
        {
            if(other.gameObject != null)
            {
                other.gameObject.SetActive(false);
                //trigger door opening and end game scenario
                onRoomComplete?.Invoke();
            }
        }
    }
}
