using UnityEngine;

public class SolarSailsController : MonoBehaviour
{
    public GameObject sun;

    private SpaceShipPhysics satellite;
    private Transform celestialBodyTarget = null;

    private const float rotationSpeed = 2f;
    private const float sailForce = 0.0001f;
    private const int maskSolarWind = 1 << 8;

    private void Start()
    {
        satellite = GetComponentInParent<SpaceShipPhysics>();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(sun.transform.position, new Vector3(transform.position.x - sun.transform.position.x, transform.position.y - sun.transform.position.y, 0f));
        RaycastHit hitInfo;

        if (celestialBodyTarget != null)
            transform.up = -(transform.position - celestialBodyTarget.position).normalized;
        if (Vector3.SqrMagnitude(sun.transform.right - transform.right) < 2f)//Sail orientation will produce thrust if sqrMag is [0, 2] 
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, maskSolarWind) && hitInfo.collider.gameObject == gameObject)//Check if sails receives sun
                satellite.ApplyForce(transform.right * sailForce);
    }

    public void RotateSails(float clockwise)
    {
        celestialBodyTarget = null;
        transform.Rotate(new Vector3(0, 0, clockwise * rotationSpeed));
    }

    public void SetCelestialBodyTarget(Transform target)
    {
        celestialBodyTarget = target;
    }
}
