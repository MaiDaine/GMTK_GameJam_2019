﻿using UnityEngine.UI;
using UnityEngine;

namespace GameJam
{
    public class SolarSailsController : MonoBehaviour
    {
        public GameObject sun;
        public ParticleSystem protonsEffect;
        public ParticleSystem boostEffect;

        private SpaceShip ship;
        private Transform celestialBodyTarget = null;
        private float orbitModification;
        private bool boosted = false;
        private Quaternion startRotation;

        private const float rotationSpeed = 2f;
        private const float sailForce = 0.000030f;
        private const int maskSolarWind = 1 << 8;

        private void Start()
        {
            ship = GetComponentInParent<SpaceShip>();
            startRotation = transform.rotation;
        }

        private void FixedUpdate()
        {
            Ray ray = new Ray(sun.transform.position, new Vector3(transform.position.x - sun.transform.position.x, transform.position.y - sun.transform.position.y, 0f));
            RaycastHit hitInfo;

            if (celestialBodyTarget != null)
                transform.up = orbitModification * (transform.position - celestialBodyTarget.position).normalized;

            if (Vector3.SqrMagnitude(sun.transform.right - transform.right) < 2f)//Sail orientation will produce thrust if sqrMag is [0, 2]
            {
                if (!protonsEffect.isPlaying)
                    protonsEffect.Play();
                if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity, maskSolarWind) && hitInfo.collider.gameObject == gameObject)//Check if sails receives sun
                {
                    if (boosted)
                        ship.ApplyForce(transform.right * sailForce);
                    else
                        ship.ApplyForce(transform.right * sailForce * 2);
                }
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

        public void SetBoost(bool status)
        {
            boosted = status;
            if (status)
                boostEffect.Play();
            else
                boostEffect.Stop();
        }
    }
}