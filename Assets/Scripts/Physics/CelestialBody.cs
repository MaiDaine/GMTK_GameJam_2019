using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace GameJam
{
    public class CelestialBody : MonoBehaviour
    {
        public float mass;
        public Text distanceText;

        private SpaceShip ship = null;

        private const float distanceScale = 1000f;

        private void FixedUpdate()
        {
            if (ship != null)
            {
                float force = (mass * ship.mass) / Mathf.Pow(distanceScale * Vector3.Distance(transform.position, ship.gameObject.transform.position), 2);
                Vector3 otherPos = ship.gameObject.transform.position;

                ship.ApplyForce(new Vector3((transform.position.x - otherPos.x) * force, (transform.position.y - otherPos.y) * force, 0f));
                distanceText.text = Vector3.Distance(transform.position, ship.gameObject.transform.position).ToString("F2");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            ship = other.GetComponent<SpaceShip>();
            if (ship != null)
                distanceText.gameObject.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            SpaceShip obj = other.GetComponent<SpaceShip>();
            if (obj != null)
            {
                ship = null;
                distanceText.gameObject.SetActive(false);
            }
        }
    }
}