using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject startPosition;
    public Vector2 blBound;
    public Vector2 trBound;

    private SolarSailsController sailsController;
    private float boosterReserve = 1f;

    private const int maskSolarWind = 1 << 8;

    private void Awake()
    {
        sailsController = GetComponentInChildren<SolarSailsController>();
    }

    private void Update()
    {
        //Targeting
        if (Input.GetMouseButtonDown(0))
            SetOrbit(1f);
        else if (Input.GetMouseButton(1))
            SetOrbit(-1f);

        //Sails control
        if (Input.GetKey(KeyCode.Q))
            sailsController.RotateSails(1);
        else if (Input.GetKey(KeyCode.D))
            sailsController.RotateSails(-1);
        if (Input.GetKey(KeyCode.Z) && boosterReserve > 0f)
        {
            sailsController.SetBoost(true);
            boosterReserve -= Time.deltaTime;
        }
        else
            sailsController.SetBoost(false);

        //Time control
        if (Input.GetKeyDown(KeyCode.KeypadPlus) && Time.timeScale < 5)
            Time.timeScale += 0.5f;
        else if (Input.GetKeyDown(KeyCode.KeypadMinus) && Time.timeScale > 0.5f)
            Time.timeScale -= 0.5f;

        if (Input.GetKeyDown(KeyCode.R))
            ResetLevel();

        CheckMapBounds();
    }

    public void ResetLevel()
    {
        GetComponent<SpaceShipPhysics>().ResetState();
        gameObject.transform.position = startPosition.transform.position;
        GetComponentInChildren<TrailRenderer>().Clear();
        GetComponentInChildren<TrailRenderer>().AddPosition(transform.position);
        Camera.main.GetComponent<CameraController>().ResetCamera();
    }

    private void SetOrbit(float expand)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, maskSolarWind) && hitInfo.collider.tag != "Player")
            sailsController.SetCelestialBodyTarget(hitInfo.collider.gameObject.transform, expand);
    }

    private void CheckMapBounds()
    {
        if (transform.position.x > trBound.x || transform.position.x < blBound.x
            || transform.position.y > trBound.y || transform.position.y < blBound.y)
            ResetLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CelestialBody")
            ResetLevel();
    }
}