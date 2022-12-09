using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Settings")]
    [Header("Настройка области спавна")]
    [SerializeField] private float _xBorderMax;
    [SerializeField] private float _xBorderMin;
    [SerializeField] private float _zBorderMax;
    [SerializeField] private float _zBorderMin;
    
    [Header("Управление объектами для спавна")]
    [SerializeField] private int _obstaclesAmount;
    [SerializeField] private List<GameObject> _obstaclesVariants;

    [Header("Хранилище объектов")] 
    [SerializeField] private Transform _obstStorage;
    void Start()
    {
        for (int i = 0; i < _obstaclesAmount; i++)
        {
            var position = new Vector3(
                Random.Range(_xBorderMax, _xBorderMin), 
                transform.position.y, 
                Random.Range(_zBorderMax, _zBorderMin));
            var rotation = Quaternion.Euler(transform.position.x, Random.Range(0f, 360f), transform.position.z);
            Instantiate(_obstaclesVariants[Random.Range(0, _obstaclesVariants.Count)],  position, rotation, _obstStorage);
        }
    }
}
