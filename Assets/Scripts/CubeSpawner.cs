using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    private Stack<Cube> _spawnCubes = new Stack<Cube>();

    public Stack<Cube> TrySpawn(Cube cube)
    {
        int minValue = 0;
        int maxValue = 100;

        _spawnCubes.Clear();

        if (Random.Range(minValue, maxValue + 1) <= cube.ChanceOfSpawn)
            SpawnRandomNumberOfTimes(cube);

        return _spawnCubes;
    }

    private void Spawn(Cube cube)
    {
        int divider = 2;
        int chanceOfSpawnOfCopy = cube.ChanceOfSpawn / divider;
        var scaleOfCopy = cube.transform.localScale / divider;
        var colorOfCopy = Random.ColorHSV();

        Cube cubeCopy = Instantiate(cube, transform);
        cubeCopy.Init(scaleOfCopy, colorOfCopy, chanceOfSpawnOfCopy);
        
        _spawnCubes.Push(cubeCopy);
    }

    private void SpawnRandomNumberOfTimes(Cube cube)
    {
        int minValue = 2;
        int maxValue = 6;
        int randomNumber = Random.Range(minValue, maxValue + 1);

        for (int i = 0; i < randomNumber; i++)
            Spawn(cube);
    }
}
