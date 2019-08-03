using UnityEngine;

public class SpaceShipPhysics : MonoBehaviour
{
    public Vector3 startVelocity;
    public float satelliteMass;

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
    }
    
}
