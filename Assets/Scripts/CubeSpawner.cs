using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Stack<Cube> TrySpawn(Cube cube)
    {
        Stack<Cube> cubes = new Stack<Cube>();
        int minValue = 0;
        int maxValue = 100;

        if (Random.Range(minValue, maxValue + 1) <= cube.ChanceOfSpawn)
            cubes = SpawnRandomNumberOfTimes(cube);

        return cubes;
    }

    private Cube Spawn(Cube cube)
    {
        int divider = 2;
        int chanceOfSpawnOfCopy = cube.ChanceOfSpawn / divider;
        var scaleOfCopy = cube.transform.localScale / divider;
        var colorOfCopy = Random.ColorHSV();

        Cube cubeCopy = Instantiate(cube, transform);
        cubeCopy.Init(scaleOfCopy, colorOfCopy, chanceOfSpawnOfCopy);

        return cubeCopy;
    }

    private Stack<Cube> SpawnRandomNumberOfTimes(Cube cube)
    {
        Stack<Cube> cubes = new Stack<Cube>();
        int minValue = 2;
        int maxValue = 6;
        int randomNumber = Random.Range(minValue, maxValue + 1);

        for (int i = 0; i < randomNumber; i++)
            cubes.Push(Spawn(cube));

        return cubes;
    }
}
