using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

public List<GameObject> cameras;
public List<int> waitIntervals;

public int waitInterval1 = 0;
public int waitInterval2 = 0;
public int waitInterval3 = 0;
public int waitInterval4 = 0;
public int waitInterval5 = 0;
public int waitInterval6 = 0;
public int waitInterval7 = 0;

int camPosition = 1;
int waitSeconds = 0;


void Start()
{
        // we don't need sound
        foreach (GameObject camera in cameras)
        {
                camera.GetComponent<AudioListener>().enabled = false;
                camera.SetActive(false);
        }

        cameras[0].SetActive(true);

        waitIntervals.Add(waitInterval1);
        waitIntervals.Add(waitInterval2);
        waitIntervals.Add(waitInterval3);
        waitIntervals.Add(waitInterval4);
        waitIntervals.Add(waitInterval5);
        waitIntervals.Add(waitInterval6);
        waitIntervals.Add(waitInterval7);

        StartCoroutine("WaitAndSwitch");
}

void Update()
{



}

IEnumerator WaitAndSwitch()
{
        yield return new WaitForSeconds(waitIntervals[camPosition-1]);
        cameras[camPosition].SetActive(true);
        cameras[camPosition-1].SetActive(false);
        camPosition++;

        if (waitIntervals[camPosition-1] > 0)
                StartCoroutine("WaitAndSwitch");
}
}
