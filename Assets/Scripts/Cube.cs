using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Cube : MonoBehaviour
{
    public void Init(Vector3 scale, Color color)
    {
        transform.localScale = scale;
        GetComponent<Renderer>().material.color = color;
    }
}
