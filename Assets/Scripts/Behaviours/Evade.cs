using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : SteeringBehaviour
{

public Boid evadeTarget;
public float tweakPosition = 1f;

Flee flee;

public override Vector3 Calculate()
{
        if (evadeTarget != null)
        {
                float dist = Vector3.Distance(evadeTarget.transform.position, transform.position);
                float time = dist / boid.maxSpeed;
                Vector3 evadeTargetPos = evadeTarget.transform.position + evadeTarget.velocity * time * tweakPosition;

                flee.target = evadeTargetPos;
                return flee.Calculate();
        }
        else
        {
                return Vector3.zero;
        }
}

public void Start()
{
        // attach flee behaviour in order to use it for evade
        flee = gameObject.AddComponent(typeof(Flee)) as Flee;
        flee.enabled = false;
}
}
