using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameDataManager : MonoBehaviour
{

    public GameData data = new GameData();
    private string DATA_FOLDER;

    public void Save()
    {
        //data.eggsMissed = 2;
        data.timePassed = GameObject.Find("Timer").GetComponent<Timer>().getTimePassed(); ;
        DATA_FOLDER = Application.dataPath + "/Data/";
        int saveNumber = 1;
        while (File.Exists(DATA_FOLDER + "save_" + saveNumber + ".txt"))
        {
            saveNumber++;
            Debug.Log("next num");
        }
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        if (!Directory.Exists(DATA_FOLDER))
        {
            Directory.CreateDirectory(DATA_FOLDER);
        }
        Debug.Log(DATA_FOLDER + "save_" + saveNumber + ".txt");
        File.WriteAllText(DATA_FOLDER + "save_" + saveNumber + ".txt", json);
    }

}