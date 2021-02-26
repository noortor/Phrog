using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrog : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * rotateSpeed);
    }
}
