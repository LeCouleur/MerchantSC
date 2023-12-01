using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f; // speed at which the camera moves
    public float zoomSpeed = 20f; // speed at which the camera zooms
    public float zoomMin = 1f; // minimum zoom distance
    public float zoomMax = 5f; // maximum zoom distance
    public float xPanLimit = 13f; // pan limit on the X-axis
    public float yPanLimit = 5f; // pan limit on the Y-axis
    public float maxPositiveYPanLimit = 5f; // maximum positive pan limit on the Y-axis
    public float maxNegativeYPanLimit = 10f; // maximum negative pan limit on the Y-axis

    private Camera mainCamera;
    private Vector3 initialPosition;
    private float initialSize;
    private float currentZoom;

    void Start()
    {
        mainCamera = Camera.main;
        initialPosition = mainCamera.transform.position;
        initialSize = mainCamera.orthographicSize;
        currentZoom = initialSize;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            StartCoroutine(Zoom(scroll));
        }

        if (Input.mousePosition.x >= Screen.width - panSpeed)
        {
            StartCoroutine(Pan(Vector3.right));
        }
        else if (Input.mousePosition.x <= panSpeed)
        {
            StartCoroutine(Pan(Vector3.left));
        }
        if (Input.mousePosition.y >= Screen.height - panSpeed)
        {
            StartCoroutine(Pan(Vector3.up));
        }
        else if (Input.mousePosition.y <= panSpeed)
        {
            StartCoroutine(Pan(Vector3.down));
        }
    }

    IEnumerator Zoom(float scroll)
    {
        while (scroll != 0)
        {
            currentZoom -= scroll * zoomSpeed * Time.deltaTime;
            currentZoom = Mathf.Clamp(currentZoom, zoomMin, zoomMax);
            mainCamera.orthographicSize = currentZoom;
            scroll = Input.GetAxis("Mouse ScrollWheel");
            yield return null;
        }
    }

    IEnumerator Pan(Vector3 direction)
    {
        float edgeDistance = panSpeed * Time.deltaTime;

        while (IsMouseNearEdge(edgeDistance))
        {
            float adjustedXPanLimit = xPanLimit;
            float adjustedYPanLimit = yPanLimit;
            float xPanSpeed = panSpeed; // Adjust the speed for X-axis panning
            float yPanSpeed = panSpeed; // Adjust the speed for Y-axis panning

            if (direction.y > 0)
            {
                adjustedYPanLimit = Mathf.Lerp(yPanLimit, maxPositiveYPanLimit, currentZoom / zoomMax);
            }
            else if (direction.y < 0)
            {
                adjustedYPanLimit = Mathf.Lerp(yPanLimit, maxNegativeYPanLimit, currentZoom / zoomMax);
            }

            Vector3 targetPosition = mainCamera.transform.position + direction * panSpeed * Time.deltaTime;
            targetPosition.x = Mathf.Clamp(targetPosition.x, initialPosition.x - (adjustedXPanLimit * (initialSize / currentZoom)), initialPosition.x + (adjustedXPanLimit * (initialSize / currentZoom)));
            targetPosition.y = Mathf.Clamp(targetPosition.y, initialPosition.y - adjustedYPanLimit, initialPosition.y + adjustedYPanLimit);
            targetPosition.z = initialPosition.z; // Keep the Z position constant

            // Smoothly move the camera towards the target position with adjusted speeds for X-axis and Y-axis panning
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, xPanSpeed * Time.deltaTime);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, targetPosition, yPanSpeed * Time.deltaTime);

            yield return null;
        }
    }

    bool IsMouseNearEdge(float distance)
    {
        Vector3 mousePosition = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        return mousePosition.x < distance || mousePosition.x > screenWidth - distance ||
               mousePosition.y < distance || mousePosition.y > screenHeight - distance;
    }





}
