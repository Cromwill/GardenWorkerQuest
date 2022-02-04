using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderParticles : MonoBehaviour
{
    [SerializeField] private Shredder _shredder;
    [SerializeField] private ParticleSystem[] _particles;

    private void OnEnable()
    {
        _shredder.DragableRecieved += Play;
    }

    private void OnDisable()
    {
        _shredder.DragableRecieved += Play;
    }

    private void Play()
    {
        foreach (var particles in _particles)
        {
            particles.Play();
        }
    }
}
