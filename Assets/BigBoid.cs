using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBoid : MonoBehaviour
{

Vector3 velocity = Vector3.zero;
Vector3 acceleration = Vector3.zero;
Vector3 force = Vector3.zero;
float mass = 1;
float speed;

float maxSpeed = 5;
float maxForce = 10;

[Range(0.0f, 10.0f)]
public float damping = 0.01f;
[Range(0.0f, 1.0f)]
public float banking = 0.1f;



public Transform targetTransform;
public Vector3 targetVector;

public bool playerSteeringEnabled = false;
public float steeringForce = 100;

// SEEK
public bool seekEnabled = false;

// FLEE
public bool fleeEnabled = false;

// ARRIVE
public bool arriveEnabled = false;
public float arriveDistance = 10;

// PATH FOLLOW
public bool pathFollowEnabled = false;
public Path path;

// PURSUE
public bool pursueEnabled = false;
public BigBoid pursueTargetBigBoid;

// EVADE
public bool evadeEnabled = false;
public BigBoid evadeTargetBigBoid;




public Vector3 Seek(Vector3 target)
{
        Vector3 toTarget = target - transform.position;
        Vector3 desiredVelocity = Vector3.Normalize(toTarget) * maxSpeed;
        Vector3 force = desiredVelocity - velocity;
        return force;
}

public Vector3 Flee(Vector3 target)
{
        Vector3 toTarget = transform.position - target;
        Vector3 desiredVelocity = Vector3.Normalize(toTarget) * maxSpeed;
        Vector3 force = desiredVelocity - velocity;
        return force;
}

public Vector3 Arrive(Vector3 target)
{
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;

        float decelerationTweaker = 0.3f;
        float arriveSpeed = maxSpeed;

        if (distance < arriveDistance)
                arriveSpeed = (distance / arriveDistance * decelerationTweaker) * maxSpeed;

        Vector3 desiredVelocity = Vector3.Normalize(toTarget) * arriveSpeed;
        Vector3 force = desiredVelocity - velocity;
        return force;
}

public Vector3 PathFollow()
{
        if (!path.looped && path.current == path.waypoints.Count - 1)
        {
                return Arrive(path.waypoints[path.waypoints.Count-1]);
        }
        else
        {
                if ((transform.position - path.waypoints[path.current]).magnitude < 1)
                {
                        path.current = (path.current + 1) % path.waypoints.Count;
                }
        }
        return Seek(path.waypoints[path.current]);
}

public Vector3 Pursue(BigBoid pursueTarget)
{
        float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);
        float time = dist / maxSpeed;
        Vector3 pursueTargetPos = pursueTarget.transform.position + pursueTarget.velocity * time;

        return Seek(pursueTargetPos);
}

public Vector3 Evade(BigBoid evadeTarget)
{
        float dist = Vector3.Distance(evadeTarget.transform.position, transform.position);
        float time = dist / maxSpeed;
        Vector3 evadeTargetPos = evadeTarget.transform.position + evadeTarget.velocity * time;

        return Flee(evadeTargetPos);
}

public Vector3 PlayerSteering()
{
        Vector3 force = Vector3.zero;

        force += Input.GetAxis("Vertical") * transform.forward * steeringForce;

        Vector3 projectedRight = transform.right;
        projectedRight.y = 0;
        projectedRight.Normalize();

        force += Input.GetAxis("Horizontal") * projectedRight * steeringForce * 0.2f;

        return force;
}

public Vector3 CalculateForce()
{
        Vector3 f = Vector3.zero;

        if (targetTransform != null)
        {
                targetVector = targetTransform.position;
        }
        if (seekEnabled)
                f += Seek(targetVector);
        if (fleeEnabled)
                f += Flee(targetVector);
        if (arriveEnabled)
                f += Arrive(targetVector);
        if (pathFollowEnabled)
                f += PathFollow();
        if (pursueEnabled)
                f += Pursue(pursueTargetBigBoid);
        if (evadeEnabled)
                f += Evade(evadeTargetBigBoid);

        if (playerSteeringEnabled)
        {
                f += PlayerSteering();
        }

        return f;
}

void Update()
{
        force = CalculateForce();
        acceleration = force / mass;
        velocity = velocity + acceleration * Time.deltaTime;
        transform.position = transform.position + velocity * Time.deltaTime;
        speed = velocity.magnitude;

        if (speed > 0)
        {
                Vector3 tempUp = Vector3.Lerp(transform.up, Vector3.up + (acceleration * banking), Time.deltaTime * 3.0f);
                transform.LookAt(transform.position + velocity, tempUp);

                velocity -= (damping * velocity * Time.deltaTime);
        }
}
}
