using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmonic : SteeringBehaviour
{
public float frequency = 0.3f;
public float radius = 10.0f;

public float theta = 0;
public float amplitude = 80;
public float distance = 5;

public enum Axis { Horizontal, Vertical };

public Axis axis = Axis.Horizontal;

Seek seek;

Vector3 target;
Vector3 worldTarget;

private void OnDrawGizmos()
{
        if (Application.isPlaying && isActiveAndEnabled)
        {
                Vector3 localCp = (Vector3.forward * distance);
                Vector3 worldCP = transform.TransformPoint(localCp);
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(worldCP, radius);
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, worldTarget);
        }
}

public override Vector3 Calculate()
{
        float n  = Mathf.Sin(theta);
        float angle = n * amplitude * Mathf.Deg2Rad;

        Vector3 rot = transform.rotation.eulerAngles;

        rot.x = 0;
        if (axis == Axis.Horizontal)
        {
                target.x = Mathf.Sin(angle);
                target.z = Mathf.Cos(angle);
                rot.z = 0;
        }
        else
        {
                target.y = Mathf.Sin(angle);
                target.z = Mathf.Cos(angle);
        }
        target *= radius;

        Vector3 localtarget = target + Vector3.forward * distance;
        worldTarget = transform.position + Quaternion.Euler(rot) * localtarget;

        theta += frequency * Time.deltaTime * Mathf.PI * 2.0f;

        seek.target = worldTarget;
        return seek.Calculate();
}

public void Start()
{
        seek = gameObject.AddComponent(typeof(Seek)) as Seek;
        seek.enabled = false;
}
}
