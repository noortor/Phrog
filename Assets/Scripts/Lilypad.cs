using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lilypad : MonoBehaviour
{

    // Start is called before the first frame update
    private float scrollSpeed;
    void Start()
    {
        // scrollSpeed = GameObject.Find("Main Camera").GetComponent<Camera>().scrollSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 lilypadPos = this.transform.position;
        // this.transform.position = new Vector3(lilypadPos.x + scrollSpeed, lilypadPos.y, lilypadPos.z);
    }

    void OnBecameInvisible()
    {
        Debug.Log("desttoyed lilypad");
        Destroy(this);
    }
}
