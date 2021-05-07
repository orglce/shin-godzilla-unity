using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodzillaMissileTrigger : MonoBehaviour
{

public GameObject trigger;
public GameObject godzilla;
public GameObject missile;
public CameraSwitch cameraSwitcher;

bool swichedFirst = true;

void Start()
{

}

void Update()
{
        if (Vector3.Distance(trigger.transform.position, godzilla.transform.position) < 150  && swichedFirst)
        {

                cameraSwitcher.Switch();
                swichedFirst = false;
                Invoke("LaunchProjectile", 1.0f);
        }
}

void LaunchProjectile()
{
        missile.GetComponent<Boid>().enabled = true;
        Invoke("SwitchCamera", 2.0f);

}

void SwitchCamera()
{
        cameraSwitcher.Switch();
}
}
