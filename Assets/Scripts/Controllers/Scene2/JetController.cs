using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetController : MonoBehaviour
{
public GameObject godzillaHead;
public GameObject missilePrefab;

void Start()
{
        GetComponent<StateMachine>().ChangeState(new PatrolStateJet());
}

// Update is called once per frame
void Update()
{

}

public void LaunchMissile()
{
        GameObject bullet = GameObject.Instantiate<GameObject>(missilePrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;

        bullet.GetComponent<Seek>().targetGameObject = godzillaHead;
}
}
