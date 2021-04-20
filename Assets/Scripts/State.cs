using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PatrolStateJet : State
{
public override void Enter()
{
}

public override void Think()
{

        if (Vector3.Distance(owner.GetComponent<JetController>().godzilla.transform.position, owner.transform.position) < 300)
        {
                owner.ChangeState(new ShootMissileJet());
        }
}

public override void Exit()
{
}
}

class ShootMissileJet : State
{
public override void Enter()
{
}

public override void Think()
{
        Debug.Log("Shooting!!!!!!!!!!!!!!!!!111");

        if (Vector3.Distance(owner.GetComponent<JetController>().godzilla.transform.position, owner.transform.position) > 300)
        {
                owner.ChangeState(new PatrolStateJet());
        }
}

public override void Exit()
{
}
}
