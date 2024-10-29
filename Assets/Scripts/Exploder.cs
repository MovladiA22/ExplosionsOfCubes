using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private ClickDetector _clickDetector;
    [SerializeField] float _explosionRadius;
    [SerializeField] float _explosionForce;

    private void OnEnable()
    {
        _clickDetector.CubeClicked += Explode;
    }

    private void OnDisable()
    {
        _clickDetector.CubeClicked -= Explode;
    }

    private void Explode(Rigidbody rigidbody)
    {
        foreach (Rigidbody explodableObject in GetExplodableObjects(rigidbody))
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(Rigidbody rigidbody)
    {
        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        foreach (var child in rigidbody.GetComponentsInChildren<Rigidbody>())
        {
            explodableObjects.Add(child);
        }

        return explodableObjects;
    }
}
