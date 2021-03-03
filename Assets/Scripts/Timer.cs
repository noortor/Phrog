using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 60f;

    [SerializeField] Text countdownText;

    private void Start() {
        currentTime = startingTime;
    }

    void Update() {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = "Time left: " + currentTime.ToString("0");
        if (currentTime <= 0) {
            GameObject.Find("Phrog").GetComponent<Phrog>().Die();
        }
    }

    public float getTimePassed() {
        return startingTime - currentTime;
    }
  
}