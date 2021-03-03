using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoseGame()
    {
        SceneManager.LoadScene("LoseScene");
        GameObject.FindWithTag("DataManager").GetComponent<GameDataManager>().Save();
        // GameDataManager.Save();
    }
    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
        GameObject.FindWithTag("DataManager").GetComponent<GameDataManager>().Save();
        //GameDataManager.Save();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
