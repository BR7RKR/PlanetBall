using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Finish : MonoBehaviour
{
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private Color _newColor;
    
    private MeshRenderer _meshRenderer;
    private AudioSource _audioSource;
    
    public bool IsFinished { get; private set; }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_winSound);
            _meshRenderer.material.color = _newColor;
            Time.timeScale = 0;
            IsFinished = true;
        }
    }
}
