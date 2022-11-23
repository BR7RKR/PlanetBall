using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMenu : MonoBehaviour
{
    [SerializeField] private float _speedOfRotation;

    private void Start()
    {
        _speedOfRotation *= Mathf.Deg2Rad;
    }

    void Update()
    {
        RotateConstantly();
    }

    private void RotateConstantly()
    {
        transform.Rotate(0, _speedOfRotation * Time.deltaTime, 0);
    }
}
