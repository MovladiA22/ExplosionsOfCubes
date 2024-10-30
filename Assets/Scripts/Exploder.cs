using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(Stack<Cube> explodableObjects)
    {
        foreach (var explodableObject in explodableObjects)
            explodableObject.Rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}