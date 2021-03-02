using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int eggCount;
    Text eggCountText;
    void Start()
    {
        eggCount = 0;
        eggCountText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        eggCountText.text = "Eggs: " + eggCount;
    }
}
