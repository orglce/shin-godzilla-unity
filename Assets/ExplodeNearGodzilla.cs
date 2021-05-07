using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeNearGodzilla : MonoBehaviour
{
public GameObject godzilla;
ParticleSystem particleSystem;
void Start()
{
        particleSystem = GetComponent<ParticleSystem>();
}

void Update()
{
        if (Vector3.Distance(godzilla.transform.position, transform.position) < 10)
        {
                particleSystem.Play();
                GetComponent<AudioSource>().Play();
                if (GetComponent<Boid>() != null)
                        GetComponent<Boid>().enabled = false;
                if (GetComponent<BulletMovingForward>() != null)
                        GetComponent<BulletMovingForward>().enabled = false;
                Destroy(gameObject, 2f);

        }
}
}
