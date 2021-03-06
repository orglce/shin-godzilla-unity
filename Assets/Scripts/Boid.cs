using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();

[HideInInspector]
public Vector3 velocity = Vector3.zero;
Vector3 acceleration = Vector3.zero;
Vector3 force = Vector3.zero;
float mass = 1;

public bool lookAtCustom = false;

public float maxSpeed = 5;
public float maxForce = 100;

public bool bankingEnabled = true;
[Range(0.0f, 10.0f)]
public float damping = 0.01f;
[Range(0.0f, 1.0f)]
public float banking = 0.1f;

public void OnDrawGizmos()
{
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + velocity);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + acceleration);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + force);
}

public Vector3 CalculateForce()
{
        Vector3 force = Vector3.zero;

        foreach (SteeringBehaviour b in behaviours)
        {
                if (b.isActiveAndEnabled)
                {
                        force += b.Calculate() * b.weight;
                        float f = force.magnitude;
                        if (f >= maxForce)
                        {
                                force = Vector3.ClampMagnitude(force, maxForce);
                                break;
                        }
                }
        }
        return force;
}

void Start()
{
        SteeringBehaviour[] behaviours = GetComponents<SteeringBehaviour>();
        foreach (SteeringBehaviour b in behaviours)
                this.behaviours.Add(b);
}

void Update()
{
        force = CalculateForce();

        // Vector3 acceleration = force / mass;
        // acceleration = Vector3.Lerp(acceleration, newAcceleration, Time.deltaTime);

        acceleration = force / mass;

        velocity = velocity + acceleration * Time.deltaTime;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        if (velocity.magnitude > 0)
        {
                if (bankingEnabled)
                {
                        Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
                        if (!lookAtCustom)
                                transform.LookAt(transform.position + velocity, tempUp);

                        transform.position = transform.position + velocity * Time.deltaTime;
                        velocity -= (damping * velocity * Time.deltaTime);
                }
                else
                {
                        if (!lookAtCustom)
                                transform.LookAt(transform.position + velocity, transform.up);
                        transform.position = transform.position + velocity * Time.deltaTime;
                }
        }
}
}
