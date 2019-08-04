using UnityEngine;

namespace GameJam
{
    public class SpaceShip : MonoBehaviour
    {
        public Vector3 startVelocity;
        public float mass;

        private Vector3 velocity;

        private void Awake()
        {
            ResetState();
        }

        private void FixedUpdate()
        {
            transform.position += velocity;
        }

        public void ApplyForce(Vector3 force)
        {
            velocity += force;
        }

        public void ResetState()
        {
            velocity = startVelocity;
            GetComponentInChildren<SolarSailsController>().SetSailNeutralState();
        }

    }
}