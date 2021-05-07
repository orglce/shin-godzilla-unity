using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliController : MonoBehaviour
{

public GameObject topPoint;
public GameObject godzilla;
public List<GameObject> heliFleet = new List<GameObject>();


void Start()
{
        GetComponent<StateMachine>().ChangeState(new HeliRisingState());
}

public void startFleetFiring() {
        foreach (GameObject heli in heliFleet)
        {
                heli.GetComponent<CamLookAt>().enabled = true;
                heli.GetComponent<HeliShooting>().enabled = true;
        }
}

}
