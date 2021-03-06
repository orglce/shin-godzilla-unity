using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class Constrain : SteeringBehaviour
{
public GameObject container;
bool chooseRandomPoint = true;
Seek seek;
public bool isBoidInside = false;

public override Vector3 Calculate()
{
        if (container != null && !isBoidInside)
        {
                if (chooseRandomPoint)
                {
                        seek.target = RandomPointInBounds(container.GetComponent<Collider>().bounds);
                        chooseRandomPoint = false;
                }
                return seek.Calculate();
        }
        else
        {
                chooseRandomPoint = true;
                return Vector3.zero;
        }
}

public static Vector3 RandomPointInBounds(Bounds bounds) {
        return new Vector3(Random.Range(bounds.min.x/2, bounds.max.x/2), Random.Range(bounds.min.y/2, bounds.max.y/2), Random.Range(bounds.min.z/2, bounds.max.z/2));
}

public void Start()
{
        seek = gameObject.AddComponent(typeof(Seek)) as Seek;
        seek.enabled = false;
}
}
