using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PatrolStateJet : State
{

JetController jetConroller;
public override void Enter()
{
        jetConroller = owner.GetComponent<JetController>();
}

public override void Think()
{

        // launch missile if plane is in certain range and is looking at godzilla
        if (Vector3.Distance(jetConroller.godzillaHead.transform.position, owner.transform.position) > 800 &&
            Vector3.Distance(jetConroller.godzillaHead.transform.position, owner.transform.position) < 1000 &&
            Vector3.Dot(jetConroller.godzillaHead.transform.position - owner.transform.position, owner.transform.forward) > 0)
        {
                jetConroller.LaunchMissile();
        }
}

public override void Exit()
{
}
}

class HeliRisingState : State
{

HeliController heliController;
public override void Enter()
{
        heliController = owner.GetComponent<HeliController>();
        owner.GetComponent<Seek>().enabled = false;
        owner.GetComponent<HeliShooting>().enabled = false;

}

public override void Think()
{
        if (Vector3.Distance(heliController.topPoint.transform.position, owner.transform.position) < 20)
        {
                owner.ChangeState(new HeliSeekingState());
        }
}

public override void Exit()
{
}
}

class HeliSeekingState : State
{

HeliController heliController;
public override void Enter()
{
        heliController = owner.GetComponent<HeliController>();
        owner.GetComponent<Seek>().enabled = true;
        owner.GetComponent<PathFollow>().enabled = false;
        owner.GetComponent<HeliShooting>().enabled = false;


}

public override void Think()
{
        if (Vector3.Distance(heliController.godzilla.transform.position, owner.transform.position) < 300)
        {
                owner.GetComponent<HeliShooting>().enabled = true;
                owner.GetComponent<Boid>().enabled = false;
                owner.GetComponent<CamLookAt>().enabled = true;
                heliController.startFleetFiring();
        }
}

public override void Exit()
{
}
}

class GodzillaMovingState : State
{

GodzillaController godzillaController;
public override void Enter()
{
        godzillaController = owner.GetComponent<GodzillaController>();

}

public override void Think()
{
        if (Vector3.Distance(godzillaController.endPoint.transform.position, owner.transform.position) < 20)
        {
                owner.GetComponent<Boid>().enabled = false;
                owner.GetComponent<PathFollow>().enabled = false;
        }
}

public override void Exit()
{
}
}
