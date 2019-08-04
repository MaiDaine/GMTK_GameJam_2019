using UnityEngine.UI;
using UnityEngine;

namespace GameJam
{
    public class SolarSailsController : MonoBehaviour
    {
        public GameObject sun;
        public ParticleSystem protonsEffect;

        private SpaceShip ship;
        private Transform celestialBodyTarget = null;
        private float orbitModification;
        private Quaternion startRotation;

        private const float rotationSpeed = 2f;
        private const float sailForce = 0.0004f;
        private const int maskSolarWind = 1 << 8;

        private void Awake()
        {
            ship = GetComponentInParent<SpaceShip>();
            startRotation = transform.rotation;
        }

        private void FixedUpdate()
        {
            //Ray ray = new Ray(transform.position, new Vector3(sun.transform.position.x, 0f, 0f));
            //RaycastHit hitInfo;

            if (celestialBodyTarget != null)
                transform.up = orbitModification * (transform.position - celestialBodyTarget.position).normalized;

            if (Vector3.SqrMagnitude(sun.transform.right - transform.right) < 2f)//Sail orientation will produce thrust if sqrMag is [0, 2]
            {
                //if (!Physics.Raycast(ray, out hitInfo, 10000f, maskSolarWind))//Check if sails receives sun
                //{
                    if (!protonsEffect.isPlaying)
                        protonsEffect.Play();
                        ship.ApplyForce(transform.right * sailForce);
                //}
                //else if (protonsEffect.isPlaying)
                //    protonsEffect.Stop();
            }
            else if (protonsEffect.isPlaying)
                protonsEffect.Stop();
        }

        public void RotateSails(float clockwise)
        {
            celestialBodyTarget = null;
            transform.Rotate(new Vector3(0, 0, clockwise * rotationSpeed));
        }

        public void SetSailNeutralState()
        {
            celestialBodyTarget = null;
            transform.rotation = startRotation;
        }

        public void SetCelestialBodyTarget(Transform target, float expand)
        {
            celestialBodyTarget = target;
            orbitModification = expand;
        }
    }
}