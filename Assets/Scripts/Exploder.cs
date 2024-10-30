using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    Rigidbody explodableObject;

    public void Explode(GameObject gameObjectCube)
    {
        explodableObject = gameObjectCube.GetComponent<Rigidbody>();
        explodableObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}