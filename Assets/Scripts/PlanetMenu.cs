using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMenu : MonoBehaviour
{
    [SerializeField] private float _angleOfRotation;
    [SerializeField] private MenuUI _menuUI;
    

    void Update()
    {
        if (!_menuUI.IsShowingControls)
            RotateConstantly();
        else Rotate();
    }

    private void RotateConstantly()
    {
        transform.Rotate(0, _angleOfRotation, 0);
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, _angleOfRotation, 0);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, -_angleOfRotation, 0);
    }
}
