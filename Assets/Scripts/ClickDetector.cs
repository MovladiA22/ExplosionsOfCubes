using UnityEngine;

public class ClickDetector : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Exploder _exploder;

    private void Update()
    {
        ProcessClick();
    }

    private void ProcessClick()
    {
        int numberForMouseButton = 0;

        if (Input.GetMouseButtonDown(numberForMouseButton))
        {
            float maxDistance = 100;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                if (hit.collider.TryGetComponent(out Cube cube))
                {
                    if (_cubeSpawner.TrySpawn(cube) == false)
                        _exploder.Explode(cube);

                    Destroy(cube.gameObject);
                }
            }
        }
    }
}
