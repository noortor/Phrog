using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggLilypad : Lilypad
{

    private bool collected;
    // Start is called before the first frame update
    void Start()
    {
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        GameObject.FindWithTag("DataManager").GetComponent<GameDataManager>().data.eggsMissed ++;
        Destroy(this.gameObject);
    }

    public override void flipLilypad() {
        // do a flip
        Debug.Log("flipped egg lilypad");
        if (!collected) {
            EggCounter.eggCount += 1;
        }
        Debug.Log(EggCounter.eggCount);
        collected = true;
    }
}
