using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

public List<Vector3> waypoints = new List<Vector3>();

public int current = 0;
public bool looped = true;

public void OnDrawGizmos()
{
        int count = looped ? (transform.childCount + 1) : transform.childCount;
        Gizmos.color = Color.cyan;
        for (int i = 1; i < count; i++)
        {
                Transform prev = transform.GetChild(i - 1);
                Transform next = transform.GetChild(i % transform.childCount);
                Gizmos.DrawLine(prev.transform.position, next.transform.position);
                Gizmos.DrawSphere(prev.position, 0.2f);
                Gizmos.DrawSphere(next.position, 0.2f);
        }
}

void Start () {
        waypoints.Clear();
        int count = transform.childCount;
        for (int i = 0; i < count; i++)
        {
                waypoints.Add(transform.GetChild(i).position);
        }
}

void Update()
{

}
}
