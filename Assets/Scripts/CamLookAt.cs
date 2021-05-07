using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAt : MonoBehaviour
{

public GameObject target;

void Update()
{
        transform.LookAt(target.transform.position);
}
}
