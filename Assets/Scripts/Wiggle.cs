using UnityEngine;
using System.Collections;

public class Wiggle : MonoBehaviour {

public AnimationCurve curve;
public Vector3 distance;
public float speed;

private Quaternion origRotation;
private Quaternion startRot, toRot;
private float timeStart;

public float randomAngle = 10f;


// Use this for initialization
void Start () {
        origRotation = transform.rotation;
        startRot = transform.rotation;

        Vector3 r = new Vector3(Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle)) * Time.deltaTime * 100;
        toRot = origRotation * Quaternion.Euler(r.x, r.y, r.z);

}

// Update is called once per frame
void Update () {
        if (Quaternion.Angle(toRot, transform.rotation) > 10)
        {
                transform.rotation = Quaternion.Slerp(transform.rotation, toRot, Time.deltaTime);
        }
        else
        {
                startRot = transform.rotation;

                Vector3 r = new Vector3(Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle), Random.Range(-randomAngle, randomAngle)) * Time.deltaTime * 100;
                toRot = origRotation * Quaternion.Euler(r.x, r.y, r.z);
        }
}
}
