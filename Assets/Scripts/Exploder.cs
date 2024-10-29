using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explode(Rigidbody explodableObject)
    {
        explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}