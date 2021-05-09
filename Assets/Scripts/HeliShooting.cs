using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliShooting : MonoBehaviour
{

public GameObject bulletPrefab;
public GameObject spawnPoint;
public GameObject godzilla;

void Start()
{
}

void OnEnable()
{
        StartCoroutine(ShootingCoroutine());
}

void Shoot()
{
        GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab);
        bullet.GetComponent<ExplodeNearGodzilla>().godzilla = godzilla;
        bullet.transform.position = spawnPoint.transform.position;
        bullet.transform.rotation = transform.rotation;
}

System.Collections.IEnumerator ShootingCoroutine()
{
        while(true)
        {
                Shoot();
                yield return new WaitForSeconds(0.5f);
        }
}
}
