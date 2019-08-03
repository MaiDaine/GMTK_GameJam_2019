using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class CelestialBodyPhysics : MonoBehaviour
    {
        public float mass;

        private List<SpaceShipPhysics> affectedObjets;

        private const float distanceScale = 1000f;

        private void Awake()
        {
            affectedObjets = new List<SpaceShipPhysics>();
        }

        private void FixedUpdate()
        {
            foreach (SpaceShipPhysics obj in affectedObjets)
            {
                float force = (mass * obj.shipMass) / Mathf.Pow(distanceScale * Vector3.Distance(transform.position, obj.gameObject.transform.position), 2);
                Vector3 otherPos = obj.gameObject.transform.position;
                obj.ApplyForce(new Vector3((transform.position.x - otherPos.x) * force, (transform.position.y - otherPos.y) * force, 0f));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            SpaceShipPhysics obj = other.GetComponent<SpaceShipPhysics>();
            if (obj != null)
                affectedObjets.Add(obj);
        }

        private void OnTriggerExit(Collider other)
        {
            SpaceShipPhysics obj = other.GetComponent<SpaceShipPhysics>();
            if (obj != null)
                affectedObjets.Remove(obj);
        }
    }
}