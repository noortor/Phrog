using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camPos = this.transform.position;
        this.transform.position = new Vector3(camPos.x + scrollSpeed, camPos.y, camPos.z);
    }
}
