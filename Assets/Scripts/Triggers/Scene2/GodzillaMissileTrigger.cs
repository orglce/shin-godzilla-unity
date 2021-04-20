using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodzillaMissileTrigger : MonoBehaviour
{

public GameObject trigger;
public GameObject godzilla;
public GameObject missile;
public CameraSwitch cameraSwitcher;

void Start()
{

}

void Update()
{
        if (Vector3.Distance(trigger.transform.position, godzilla.transform.position) < 150)
        {
                missile.GetComponent<Boid>().enabled = true;
                cameraSwitcher.Switch();
        }
}
}
