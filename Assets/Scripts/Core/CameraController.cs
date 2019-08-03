using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerSpaceShip;

    private Camera playerCamera;

    private const float zoomMin = 1.1f;
    private const float zoomMax = 15f;

    private void Awake()
    {
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && playerCamera.orthographicSize < zoomMax)
            playerCamera.orthographicSize += 1f;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && playerCamera.orthographicSize > zoomMin)
            playerCamera.orthographicSize -= 1f;
        if (Input.GetKey(KeyCode.Space))
            ResetCamera();
    }

    public void ResetCamera()
    {
        playerCamera.transform.position = new Vector3(playerSpaceShip.transform.position.x, playerSpaceShip.transform.position.y, playerCamera.transform.position.z);
    }
}
