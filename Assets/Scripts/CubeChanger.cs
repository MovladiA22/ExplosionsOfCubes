using UnityEngine;

public class CubeChanger : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = new Renderer();
    }

    private void OnEnable()
    {
        _cubeSpawner.CubeSpawned += ChangeColor;
        _cubeSpawner.CubeSpawned += ChangeSize;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeSpawned -= ChangeColor;
        _cubeSpawner.CubeSpawned -= ChangeSize;
    }

    private void ChangeSize()
    {
        float sizeDivider = 2;

        foreach (Rigidbody rigidbody in _cubeSpawner.ChildCubes)
        {
            rigidbody.transform.localScale /= sizeDivider;
        }
    }

    private void ChangeColor()
    {
        foreach (Rigidbody rigidbody in _cubeSpawner.ChildCubes)
        {
            if (rigidbody.TryGetComponent<Renderer>(out Renderer renderer))
                renderer.material.color = Random.ColorHSV();
        }
    }
}
