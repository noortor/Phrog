using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrog : MonoBehaviour
{
    // Start is called before the first frame update
    private bool onLilypad;
    public float rotateSpeed;
    public float hopDistance;
    public float hopSpeed;
    private bool hopping;
    private Lilypad[] lilypads;

    void Start()
    {
        hopping = false;
        onLilypad = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hopping) {
            this.transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * rotateSpeed);
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }
            if (Input.GetAxis("Vertical") > 0) {
                hopping = true;
                StartCoroutine(Hop());
            }
        }
    }

    void flipLilypads() {

    }

    // public void setOnLilypad(bool newOnLilypad) {
    //     onLilypad = newOnLilypad;
    // }

    private void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("on lilypad");
		onLilypad = true;
    }

    private void OnTriggerExit2D(Collider2D coll) {
        Debug.Log("off lilypad");
        onLilypad = false;
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
        yield return new WaitForSeconds(0.2f);
        hopping = false;
        if (!onLilypad) {
            Die();
        }
    }

    void Die() {
        //do a big ded
        Debug.Log("ded");
        Destroy(this.gameObject);
        //activate gameover screen
    }
}
