using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNoThanks : MonoBehaviour
{
    [SerializeField] private int IDD;
    private int lv;
    private string keyLv = "keyLv";

    private void Start()
    {
        Load();
    }

    public void LoadNextScenee()
    {
        Time.timeScale = 1.0f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(currentSceneIndex + 2);
        
    }
    public void LoadStartScenee()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void Load()
    {
        string keyy = keyLv + IDD.ToString();
        string statuss = PlayerPrefs.GetString(keyy);

        if (statuss.Equals("savedd"))
        {
            //RestartScene();
            LoadNextScenee();

            //LoadStartScene();
        }
    }
    public void save()
    {
        string keyy = keyLv + IDD.ToString();
        PlayerPrefs.SetString(keyy, "savedd");
        PlayerPrefs.SetInt(keyLv, lv);


    }
   
}
