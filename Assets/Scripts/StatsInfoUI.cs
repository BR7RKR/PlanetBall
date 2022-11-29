using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsInfoUI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _speedPlayerText;
    [SerializeField] private TextMeshProUGUI _rotationAnglePlayerText;

    private bool _isTurnedOff;

    void Update()
    {
        ShowStats();
    }

    private void ShowStats()
    {
        var speed = Mathf.RoundToInt(_player.Rb.velocity.magnitude);
        var angle = Mathf.RoundToInt(360 - _player.gameObject.transform.eulerAngles.y);
        angle = angle == 360 ? 0 : angle;
        
        _speedPlayerText.text = $"Actual Speed: {speed}";
        _rotationAnglePlayerText.text = $"Angle of rotation: {angle}";
    }

    public void SwitchStateOfStatsUI()
    {
        gameObject.SetActive(_isTurnedOff);
        _isTurnedOff = !_isTurnedOff;
    }
}
