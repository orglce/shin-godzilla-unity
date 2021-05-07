using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
public List<GameObject> scenes = new List<GameObject>();
List<int> waitIntervals = new List<int>();

public GameObject missile;
public GameObject missileCam;

public GameObject staticObjects;

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

int scenePosition = 1;

void Start()
{
        // we don't need sound
        foreach (GameObject scene in scenes)
        {
                scene.SetActive(false);
        }

        missileCam.SetActive(false);
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

        StartCoroutine("WaitAndSwitch");
}

void Update()
{

}

IEnumerator WaitAndSwitch()
{
        yield return new WaitForSeconds(waitIntervals[scenePosition-1]);

        bool missilCamActive = false;

        switch(scenePosition)
        {
        case 1:
                scenes[0].SetActive(false);
                staticObjects.SetActive(false);
                break;

        case 4:
                scenes[1].SetActive(false);
                scenes[2].SetActive(false);
                scenes[3].SetActive(false);
                staticObjects.SetActive(true);
                break;
        case 8:
                scenes[2].SetActive(true);
                scenes[3].SetActive(true);


                break;
        case 9:


                scenes[2].SetActive(false);
                scenes[3].SetActive(false);
                scenes[8].SetActive(false);

                missilCamActive = true;
                Invoke("LaunchMissile", 2f);
                break;
        }

        scenes[scenePosition].SetActive(true);

        scenePosition++;
        if (waitIntervals[scenePosition-1] > 0)
                StartCoroutine("WaitAndSwitch");

}

void LaunchMissile()
{
        missile.GetComponent<Boid>().enabled = true;
        Invoke("AcvibateMissileCam", 2f);

}

void AcvibateMissileCam()
{
        missileCam.SetActive(true);
        Invoke("ContinueScene", 2f);
}

void ContinueScene()
{
        StartCoroutine("WaitAndSwitch");
}

}
