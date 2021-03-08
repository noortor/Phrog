using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phrog : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Tooltip("Speed at which the phrog rotates")]
    private float rotateSpeed;
    [SerializeField]
    private float hopDistance;
    [SerializeField]
    private float hopSpeed;
    private bool hopping;
    [SerializeField]
    private float max_hop_dist;
    [SerializeField]
    private float min_hop_dist;
    private HashSet<GameObject> lilypads;
    [SerializeField]
    private GameObject ruler;

    void Start()
    {
        hopping = false;
        lilypads = new HashSet<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hopping) {
            this.transform.Rotate(0.0f, 0.0f, -Input.GetAxis("Horizontal") * rotateSpeed);
            if (Input.GetKeyDown("space"))
            {
                flipLilypads();
            }
            if (Input.GetAxis("Vertical") > 0 && !hopping) {
                Debug.Log("we made it");
                hopping = true;
                StartCoroutine(jump_held());
            }
        }
    }

    void flipLilypads() {
        foreach (GameObject lilypadObject in lilypads) {
            Lilypad lilypad = null;
            if (lilypadObject.CompareTag("Lilypad")) {
                lilypad = lilypadObject.GetComponent<Lilypad>();
            } else if (lilypadObject.CompareTag("EggLilypad")) {
                lilypad = lilypadObject.GetComponent<EggLilypad>();
            } else if (lilypadObject.CompareTag("AlligatorLilypad")) {
                lilypad = lilypadObject.GetComponent<AlligatorLilypad>();
            }
            lilypad.flipLilypad();
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) {
        Debug.Log("on lilypad");
        lilypads.Add(coll.gameObject);
    }

    private void OnTriggerExit2D(Collider2D coll) {
        Debug.Log("off lilypad");
        lilypads.Remove(coll.gameObject);
    }

    private bool onPad() {
        return lilypads.Count > 0;
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
        if (!onPad()) {
            Die();
        }
    }

    IEnumerator jump_held()
    {
        
        hopDistance = min_hop_dist;
        while (Input.GetAxis("Vertical") != 0)
        {
            if(hopDistance < max_hop_dist)
            {
                hopDistance += 2;
                Vector3 startPos = this.transform.position;
                float xDist = hopDistance * Mathf.Cos(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
                float yDist = hopDistance * Mathf.Sin(this.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
                ruler.transform.position = new Vector3(startPos.x + xDist, startPos.y + yDist, 0);
            }
            
            yield return null;

        }
        StartCoroutine(Hop());
    }

    public void Die() {
        //do a big ded
        Debug.Log("ded");
        Destroy(this.gameObject);
        GameObject.FindWithTag("GameController").GetComponent<GameManager>().LoseGame();
        //activate gameover screen
    }
}
