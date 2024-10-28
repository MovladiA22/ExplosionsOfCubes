using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public event Action OnCubeClicked;

    public Rigidbody Rigidbody { get; private set; }

    private void Update()
    {
        ProcessClick();
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
                {
                    Rigidbody = rigidbody;
                    OnCubeClicked?.Invoke();
                }
            }
        }
    }
}
