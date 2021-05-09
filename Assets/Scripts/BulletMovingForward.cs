using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovingForward : MonoBehaviour
{
// Start is called before the first frame update
void Start()
{
        Destroy(gameObject, 5f);
}

// Update is called once per frame
void Update()
{
        transform.Translate(0, 0, 500 * Time.deltaTime);
}
}
