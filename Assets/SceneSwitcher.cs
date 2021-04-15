using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
// Start is called before the first frame update
void Start()
{
        StartCoroutine(ExecuteAfterTime(5));
}

IEnumerator ExecuteAfterTime(float time)
{
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene("Scene2");
}

// Update is called once per frame
void Update()
{

}
}
