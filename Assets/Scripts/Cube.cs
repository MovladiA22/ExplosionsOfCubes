using UnityEngine;

public class Cube : MonoBehaviour
{
    public void Init(Vector3 scale, Color color)
    {
        gameObject.transform.localScale = scale;
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
