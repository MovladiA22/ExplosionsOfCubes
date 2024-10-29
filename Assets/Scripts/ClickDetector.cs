using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    public event Action<Rigidbody> CubeClicked;

    private void Update()
    {
        ProcessClick();
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float maxDistance = 100;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                if (hit.collider.gameObject.TryGetComponent(out Rigidbody rigidbody))
                    CubeClicked?.Invoke(rigidbody);
            }
        }
    }
}
