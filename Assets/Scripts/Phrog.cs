using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrog : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotateSpeed;
    public float jumpDistance;
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
        Debug.Log("hop");
        float elapsedTime = 0;
        Vector3 startPos = this.transform.position;
        float xDist = jumpDistance * Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        float yDist = jumpDistance * Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        Vector3 endPos = new Vector3(startPos.x + xDist, startPos.y + yDist, startPos.z);
        while(Vector3.Distance(endPos, this.transform.position) > 0.1) {
            this.transform.position = Vector3.Lerp(startPos, endPos, elapsedTime/3);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        hopping = false;
    }
}
