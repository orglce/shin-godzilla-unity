using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : SteeringBehaviour
{
public GameObject targetGameObject = null;
public Vector3 target = Vector3.zero;

public override Vector3 Calculate()
{
        Vector3 toTarget = boid.transform.position - target;
        Vector3 desiredVelocity = Vector3.Normalize(toTarget) * boid.maxSpeed;
        Vector3 force = desiredVelocity - boid.velocity;
        return force;
}

public void Update()
{
        if (targetGameObject != null)
        {
                target = targetGameObject.transform.position;
        }
}
}
