using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneswitch : MonoBehaviour {

public List<GameObject> scenes;
List<int> waitIntervals;

public int waitInterval1 = 0;
public int waitInterval2 = 0;
public int waitInterval3 = 0;
public int waitInterval4 = 0;
public int waitInterval5 = 0;
public int waitInterval6 = 0;
public int waitInterval7 = 0;
public int waitInterval8 = 0;
public int waitInterval9 = 0;
public int waitInterval10 = 0;
public int waitInterval11 = 0;
public int waitInterval12 = 0;

int camPosition = 1;

void Start()
{
        // we don't need sound
        foreach (GameObject camera in scenes)
        {
                camera.GetComponent<AudioListener>().enabled = false;
                camera.SetActive(false);
        }

        scenes[0].SetActive(true);

        waitIntervals.Add(waitInterval1);
        waitIntervals.Add(waitInterval2);
        waitIntervals.Add(waitInterval3);
        waitIntervals.Add(waitInterval4);
        waitIntervals.Add(waitInterval5);
        waitIntervals.Add(waitInterval6);
        waitIntervals.Add(waitInterval7);
        waitIntervals.Add(waitInterval8);
        waitIntervals.Add(waitInterval9);
        waitIntervals.Add(waitInterval10);
        waitIntervals.Add(waitInterval11);
        waitIntervals.Add(waitInterval12);

        // StartCoroutine("WaitAndSwitch");
}

void Update()
{



}

public void Switch()
{
        scenes[camPosition].SetActive(true);
        scenes[camPosition-1].SetActive(false);
        camPosition++;
}

IEnumerator WaitAndSwitch()
{
        yield return new WaitForSeconds(waitIntervals[camPosition-1]);
        scenes[camPosition].SetActive(true);
        scenes[camPosition-1].SetActive(false);
        camPosition++;

        if (waitIntervals[camPosition-1] > 0)
                StartCoroutine("WaitAndSwitch");
}
}
