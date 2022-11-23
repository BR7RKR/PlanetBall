using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsInfoUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _speedPlayerText;
    [SerializeField] private TextMeshProUGUI _rotationAnglePlayerText;

    void Update()
    {
        ShowStats();
    }

    private void ShowStats()
    {
        var speed = _player.Rb.velocity.magnitude;
        var angle = Mathf.Rad2Deg * _player.gameObject.transform.rotation.y;
        
        _speedPlayerText.text = $"Actual Speed: {speed}";
        _rotationAnglePlayerText.text = $"Angle of rotation: {angle}";
    }
}
