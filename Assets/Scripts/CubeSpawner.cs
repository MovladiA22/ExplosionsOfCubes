using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] ClickDetector _clickDetector;

    private Rigidbody _cubeStandart;
    private int _chanceOfSpawn = 100;

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
        int scaleDivider = 2;
        var newScale = _cubeStandart.transform.localScale / scaleDivider;
        var newColor = Random.ColorHSV();

        Rigidbody cubeCopy = Instantiate(_cubeStandart, transform);
        cubeCopy.GetComponent<Cube>().Init(newScale, newColor);
    }

    private void SpawnRandomNumberOfTimes()
    {
        int minValue = 2;
        int maxValue = 6;
        int randomNumber = Random.Range(minValue, maxValue + 1);

        for (int i = 0; i < randomNumber; i++)
            Spawn();
    }

    private void TrySpawn(Rigidbody rigidbody)
    {
        int minValue = 0;
        int maxValue = 100;
        int chanceDivider = 2;

        _cubeStandart = rigidbody;

        if (Random.Range(minValue, maxValue + 1) <= _chanceOfSpawn)
        {
            _chanceOfSpawn /= chanceDivider;
            SpawnRandomNumberOfTimes();
        }

        Destroy(_cubeStandart.gameObject);
    }
}
