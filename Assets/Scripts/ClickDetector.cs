using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public event Action CubeClicked;

    public Rigidbody Rigidbody { get; private set; }

    private void Update()
    {
        ProcessClick();
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float maxDistance = 100;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
                {
                    Rigidbody = rigidbody;
                    CubeClicked?.Invoke();
                }
            }
        }
    }
}
