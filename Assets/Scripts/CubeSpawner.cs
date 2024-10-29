using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private ClickDetector _clickDetector;
    [SerializeField] private Exploder _exploder;

    private Cube _cubeStandart;
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

        Cube cubeCopy = Instantiate(_cubeStandart, transform);
        cubeCopy.Init(newScale, newColor);
        _exploder.Explode(cubeCopy.GetComponent<Rigidbody>());
    }

    private void SpawnRandomNumberOfTimes()
    {
        int minValue = 2;
        int maxValue = 6;
        int randomNumber = Random.Range(minValue, maxValue + 1);

        for (int i = 0; i < randomNumber; i++)
            Spawn();
    }

    private void TrySpawn(Cube cube)
    {
        int minValue = 0;
        int maxValue = 100;
        int chanceDivider = 2;

        _cubeStandart = cube;

        if (Random.Range(minValue, maxValue + 1) <= _chanceOfSpawn)
        {
            _chanceOfSpawn /= chanceDivider;
            SpawnRandomNumberOfTimes();
        }

        Destroy(_cubeStandart.gameObject);
    }
}
