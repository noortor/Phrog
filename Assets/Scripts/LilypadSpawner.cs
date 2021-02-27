using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadSpawner : MonoBehaviour
{
    public GameObject lilypad;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        StartCoroutine(SpawnLilypads());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnLilypads()
    {
        while (true)
        {
            Vector3 camPos = camera.transform.position;
            Vector3 spawnPos = new Vector3(camPos.x + 1, camPos.y, lilypad.transform.position.z);
            Instantiate(lilypad, spawnPos, Quaternion.identity);
            Debug.Log("spawning");
            yield return new WaitForSeconds(3);
        }
    }
}
