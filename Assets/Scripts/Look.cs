using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
public GameObject godzilla;
void Start()
{

}

void Update()
{
        transform.LookAt(godzilla.transform.position + new Vector3(-50f, 50f, 50f));

}
}
