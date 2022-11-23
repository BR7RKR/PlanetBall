using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMenu : MonoBehaviour
{
    [SerializeField] private float _speedOfRotation;

    void Update()
    {
        RotateConstantly();
    }

    private void RotateConstantly()
    {
        transform.Rotate(0, _speedOfRotation, 0);
    }
}
