using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(Cube cube)
    {
        float divider = cube.transform.localScale.x;

        foreach (var explodableObject in GetExplodableObjects(cube))
            explodableObject.AddExplosionForce(_explosionForce / divider, transform.position, _explosionRadius / divider);
    }

    private Stack<Rigidbody> GetExplodableObjects(Cube cube)
    {
        Stack<Rigidbody> explodableObjects = new Stack<Rigidbody>();
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
                explodableObjects.Push(hit.attachedRigidbody);
        }

        return explodableObjects;
    }
}