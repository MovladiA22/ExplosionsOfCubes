using UnityEngine;

public class CubeChanger : MonoBehaviour
{
    [SerializeField] CubeSpawner _cubeSpawner;

    private Renderer _renderer;

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
            _renderer = rigidbody.GetComponent<Renderer>();
            _renderer.material.color = new Color(Random.value, Random.value, Random.value, 1f);
        }
    }
}
