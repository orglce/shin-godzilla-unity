using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : SteeringBehaviour
{
public Boid pursueTarget;
public float tweakPosition = 1f;

Seek seek;

public override Vector3 Calculate()
{
        if (pursueTarget != null)
        {
                float dist = Vector3.Distance(pursueTarget.transform.position, transform.position);
                float time = dist / boid.maxSpeed;
                Vector3 pursueTargetPos = pursueTarget.transform.position + pursueTarget.velocity * time * tweakPosition;

                seek.target = pursueTargetPos;
                return seek.Calculate();
        }
        else
        {
                return Vector3.zero;
        }
}

public void Start()
{
        seek = gameObject.AddComponent(typeof(Seek)) as Seek;
        seek.enabled = false;
}
}
