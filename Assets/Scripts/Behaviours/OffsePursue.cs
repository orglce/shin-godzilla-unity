using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsePursue : SteeringBehaviour
{
public Boid leader;
public Vector3 targetPos;
public Vector3 worldTarget = Vector3.zero;
Vector3 offset;

Arrive arrive;
[Range(0.0f, 10.0f)]
public float stiffness = 0.5f;

public void OnDrawGizmos()
{
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(worldTarget, 1);
}

public override Vector3 Calculate()
{
        if (worldTarget == Vector3.zero)
                worldTarget = leader.transform.TransformPoint(offset);
        else
                worldTarget = Vector3.Lerp(worldTarget, leader.transform.TransformPoint(offset), Time.deltaTime * stiffness);

        float distance = Vector3.Distance(transform.position, worldTarget);
        float time = distance / boid.maxSpeed;

        targetPos = worldTarget + (leader.velocity * time);

        arrive.target = targetPos;
        return arrive.Calculate();
}

void Start()
{
        offset = transform.position - leader.transform.position;
        offset = Quaternion.Inverse(leader.transform.rotation) * offset;


        arrive = gameObject.AddComponent(typeof(Arrive)) as Arrive;
        arrive.enabled = false;
}
}
