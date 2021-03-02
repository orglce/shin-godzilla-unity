using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehaviour
{

// target on the outside of the circle
public Vector3 target = Vector3.zero;

public float distance = 20f;
public float radius = 10f;
public float randomAngle = 10f;
public bool twoD = true;

Seek seek;

Vector3 direction;

Quaternion previousRotation = Quaternion.identity;
Quaternion currentRotation = Quaternion.identity;

Vector3 newVector;
Vector3 dirVector;

public void OnDrawGizmos()
{
        Vector3 localCP = Vector3.forward * distance;
        Vector3 worldCP = transform.TransformPoint(localCP);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(worldCP, radius);
        Gizmos.DrawLine(worldCP, worldCP + target);
}

public override Vector3 Calculate()
{
        Vector3 r = new Vector3(Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle)) * Time.deltaTime * 100;
        Quaternion rotation = Quaternion.Euler(r.x, r.y, r.z);

        target = Vector3.Normalize(rotation * target) * radius;

        Vector3 localTarget = (transform.forward * distance) + target;
        if (twoD)
                localTarget.y = 0;

        seek.target = transform.position + localTarget;
        return seek.Calculate();
}

public void Start()
{
        target = transform.position + (Random.onUnitSphere * radius);

        seek = gameObject.AddComponent(typeof(Seek)) as Seek;
        seek.enabled = false;
}
}
