using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrog : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed;
    public float hopDistance;
    public float hopSpeed;
    private bool hopping;

    void Start()
    {
        hopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * rotateSpeed);
        if (Input.GetAxis("Vertical") > 0 && !hopping) {
            hopping = true;
            StartCoroutine(Hop());
        }
    }

    IEnumerator Hop() {
        float elapsedTime = 0;
        Vector3 startPos = this.transform.position;
        float xDist = hopDistance * Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        float yDist = hopDistance * Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        Vector3 endPos = new Vector3(startPos.x + xDist, startPos.y + yDist, startPos.z);
        while(Vector3.Distance(endPos, this.transform.position) > 0.1) {
            this.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime * hopSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        hopping = false;
    }
}
