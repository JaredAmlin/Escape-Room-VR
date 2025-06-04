using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightBlade : MonoBehaviour
{
    [SerializeField] private ParticleSystem _lightParticles;
    [SerializeField] private ParticleSystem _redBurstBarticles;
    [SerializeField] private AudioSource _audioSource;

    public static event Action onRoomComplete;

    private void OnTriggerStay(Collider other)
    {
        if (_lightParticles != null)
        {
            if (!_lightParticles.isPlaying)
            {
                _lightParticles.Play();
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
                if (_redBurstBarticles != null)
                {
                    _redBurstBarticles.Play();
                }

                if (_audioSource != null)
                {
                    _audioSource.Play();
                }

                other.gameObject.SetActive(false);
                //trigger door opening and end game scenario
                onRoomComplete?.Invoke();
            }
        }
    }
}
