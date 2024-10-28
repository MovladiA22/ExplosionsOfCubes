using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private ClickDetector _clickDetector;

    public event System.Action CubeSpawned;
    private List<Rigidbody> _childCubes = new List<Rigidbody>();
    private Rigidbody _cubeStandart;
    private int _chanceOfSpawn = 100;

    public List<Rigidbody> ChildCubes => _childCubes.ToList();

    private void OnEnable()
    {
        _clickDetector.CubeClicked += TrySpawn;
    }

    private void OnDisable()
    {
        _clickDetector.CubeClicked -= TrySpawn;
    }

    private void Spawn()
    {
        Rigidbody cubeCopy = Instantiate(_cubeStandart, transform.position, transform.rotation);
        
        _childCubes.Add(cubeCopy);
    }

    private void RandomTimeSpawn()
    {
        int minValue = 2;
        int maxValue = 7;

        for (int i = 0; i < Random.Range(minValue, maxValue); i++)
            Spawn();

        CubeSpawned?.Invoke();
    }

    private void TrySpawn()
    {
        int minValue = 0;
        int maxValue = 101;
        int chanceDivider = 2;

        _cubeStandart = _clickDetector.Rigidbody;

        if (Random.Range(minValue, maxValue) <= _chanceOfSpawn)
        {
            _chanceOfSpawn /= chanceDivider;
            RandomTimeSpawn();
        }

        _childCubes.Clear();
        Destroy(_cubeStandart.gameObject);
    }
}
