using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredatorController : MonoBehaviour
{
// Start is called before the first frame update
void Start()
{
        GetComponent<StateMachine>().ChangeState(new PatrolState());
        GetComponent<StateMachine>().SetGlobalState(new PatrolState());
}

// Update is called once per frame
void Update()
{

}
}
