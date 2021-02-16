using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsePursue : SteeringBehaviour
{
public Boid leader;
public Vector3 targetPos;
public Vector3 worldTarget;
Vector3 offset;

Arrive arrive;

public void OnDrawGizmos()
{
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(worldTarget, 1);
}

public override Vector3 Calculate()
{
        worldTarget = leader.transform.TransformPoint(offset);
        // worldTarget = leader.transform.position + offset;
        // offset = leader.transform.rotation * offset;
        float distance = Vector3.Distance(transform.position, worldTarget);
        float time = distance / boid.maxSpeed;

        Debug.Log(leader.transform.rotation);

        targetPos = worldTarget + (leader.velocity * time);

        arrive.target = targetPos;
        return arrive.Calculate();
}

void Start()
{
        offset = transform.position - leader.transform.position;

        Debug.Log(offset);
        Debug.Log(transform.TransformPoint(offset));

        arrive = gameObject.AddComponent(typeof(Arrive)) as Arrive;
        arrive.enabled = false;
}
}
