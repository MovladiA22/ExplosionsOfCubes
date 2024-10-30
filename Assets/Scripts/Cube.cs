using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    private int _chanceOfSpawn = 100;

    public int ChanceOfSpawn => _chanceOfSpawn;

    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public void Init(Vector3 scale, Color color, int chanceOfSpawn)
    {
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
        _chanceOfSpawn = chanceOfSpawn;
    }
}
