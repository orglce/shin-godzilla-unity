using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollow : SteeringBehaviour
{
public Path path;

public int distanceToPoint = 1;

Seek seek;
Arrive arrive;


public void OnDrawGizmos()
{
        if (isActiveAndEnabled && Application.isPlaying)
        {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, path.waypoints[path.current]);
        }
}

public override Vector3 Calculate()
{
        if (seek.target == null)
        {
                seek.target = path.waypoints[0];
        }

        if (!path.looped && path.current == path.waypoints.Count - 1)
        {
                arrive.target = path.waypoints[path.waypoints.Count-1];
                return arrive.Calculate();
        }
        else
        {
                if ((boid.transform.position - path.waypoints[path.current]).magnitude < distanceToPoint)
                {
                        path.current = (path.current + 1) % path.waypoints.Count;
                }
        }

        seek.target = path.waypoints[path.current];
        return seek.Calculate();
}

public void Start()
{
        // attach needed behaviours
        seek = gameObject.AddComponent(typeof(Seek)) as Seek;
        seek.enabled = false;
        arrive = gameObject.AddComponent(typeof(Arrive)) as Arrive;
        arrive.enabled = false;
}
}
