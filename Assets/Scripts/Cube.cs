using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private int _chanceOfSpawn = 100;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public int ChanceOfSpawn => _chanceOfSpawn;

    public Rigidbody Rigidbody => _rigidbody;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 scale, Color color, int chanceOfSpawn)
    {
        transform.localScale = scale;
        _renderer.material.color = color;
        _chanceOfSpawn = chanceOfSpawn;
    }
}
