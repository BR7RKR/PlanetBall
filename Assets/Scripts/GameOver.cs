using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Update()
    {
        if (_player.IsDead)
        {
            Time.timeScale = 0;
        }
    }
}
