using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilypadSpawner : MonoBehaviour
{
    public GameObject lilypad;
    public GameObject eggLilypad;
    public GameObject alligatorLilypad;
    private float spawnRange;
    public float eggLilypadSpawnRate;
    public float alligatorLilypadSpawnRate;


    // Start is called before the first frame update
    void Start()
    {
        spawnRange = 2f * Camera.main.orthographicSize;
        //spawnRange = cam.ScreenToWorldPoint(Screen.height);
        // maxSpawnHeight = camera.transform.position
        StartCoroutine(SpawnLilypads());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void InstantiateRandomLilypad(Vector3 spawnPos) {
        float randomVal = Random.Range(0.0f, 1.0f);
        if (randomVal < eggLilypadSpawnRate) {
            Instantiate(eggLilypad, spawnPos, Quaternion.identity);
        } else if (randomVal < eggLilypadSpawnRate + alligatorLilypadSpawnRate) {
            Instantiate(alligatorLilypad, spawnPos, Quaternion.identity);
        } else {
            Instantiate(lilypad, spawnPos, Quaternion.identity);
        }
    }

    IEnumerator SpawnLilypads()
    {
        while (true)
        {
            Vector3 camPos = Camera.main.transform.position;
            Vector3 spawnPos = new Vector3(camPos.x + 11f, Random.Range(camPos.y - spawnRange/2, camPos.y + spawnRange/2), lilypad.transform.position.z);
            InstantiateRandomLilypad(spawnPos);
            yield return new WaitForSeconds(3);
        }
    }
}
