using UnityEngine;

public class SpaceShipPhysics : MonoBehaviour
{
    public Vector3 startVelocity;
    public float satelliteMass;

    private Vector3 velocity;

    private void Awake()
    {
        velocity = startVelocity;
    }

    public void ApplyForce(Vector3 force)
    {
        velocity += force;
    }

    private void FixedUpdate()
    {
        transform.position += velocity;
    }
}
