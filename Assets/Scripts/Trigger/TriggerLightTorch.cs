using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLightTorch : MonoBehaviour
{
    [SerializeField] private Light[] _light = new Light[2];
    [SerializeField] private ParticleSystem[] _particles = new ParticleSystem[2];

    private void Start()
    {
        foreach (var particle in _particles)
        {
            particle.Pause();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.gameObject.tag == "Player")
        {
            foreach (var particle in _particles)
            {
                particle.Play();
            }
            foreach (Light light in _light)
            {
                light.enabled = true;
            }
        }
        
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            foreach (var particle in _particles)
            {
                particle.Stop();
            }
            foreach (Light light in _light)
            {
                light.enabled = false;
            }
        }
    }
}
