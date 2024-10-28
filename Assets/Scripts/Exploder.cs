using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] CubeSpawner _cubeSpawner;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;

    private void OnEnable()
    {
        _cubeSpawner.CubeSpawned += Explode;
    }

    private void OnDisable()
    {
        _cubeSpawner.CubeSpawned -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodableObject in _cubeSpawner.ChildCubes)
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}
