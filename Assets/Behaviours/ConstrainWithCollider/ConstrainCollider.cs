using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Collider))]
public class ConstrainCollider : MonoBehaviour
{

private void OnTriggerEnter(Collider other)
{
        other.gameObject.GetComponent<Constrain>().isBoidInside = true;
}

private void OnTriggerExit(Collider other)
{
        other.gameObject.GetComponent<Constrain>().isBoidInside = false;
}

void Start()
{
        GetComponent<Collider>().isTrigger = true;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
}
}
