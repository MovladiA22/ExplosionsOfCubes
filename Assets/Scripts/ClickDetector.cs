using System;
using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    public event Action<Cube> CubeClicked;

    private void Update()
    {
        ProcessClick();
    }

    private void ProcessClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float maxDistance = 100;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                    CubeClicked?.Invoke(cube);
            }
        }
    }
}
