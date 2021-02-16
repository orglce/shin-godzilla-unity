using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : SteeringBehaviour
{
public GameObject targetGameObject = null;
public Vector3 target = Vector3.zero;

public float arriveDistance = 5f;
public float decelerationTweaker = 0.3f;

public override Vector3 Calculate()
{
        Vector3 toTarget = target - boid.transform.position;
        float distance = toTarget.magnitude;

        if (distance == 0)
                return Vector3.zero;

        float arriveSpeed = boid.maxSpeed;

        if (distance < arriveDistance)
                arriveSpeed = (distance / arriveDistance * decelerationTweaker) * boid.maxSpeed;

        Vector3 desiredVelocity = Vector3.Normalize(toTarget) * arriveSpeed;
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
