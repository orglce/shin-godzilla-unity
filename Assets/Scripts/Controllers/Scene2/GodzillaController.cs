using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodzillaController : MonoBehaviour
{
public GameObject endPoint;

void Start()
{
        GetComponent<StateMachine>().ChangeState(new GodzillaMovingState());
}

// Update is called once per frame
void Update()
{

}
}
