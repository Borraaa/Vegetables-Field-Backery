using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SaveLoad : MonoBehaviour
{
    public static SaveLoad instance;
    //[SerializeField] private int IDD;
    private int lv;
    private string keyLv = "keyLv";
    //[SerializeField] private GameObject[] allObjects;



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    void Start()
    {
        Load();
        
        //ResetPrefabs();
    }

    //public void LoadNextScene()
    //{

    //    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    SceneManager.LoadScene(currentSceneIndex + 0);


    //    save();
    //}

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //ResetPrefabs();
        //ResetPrefabs();
        Save();
    }

    //public void save()
    //{
    //    string keyy = keyLv + IDD.ToString();
    //    PlayerPrefs.SetString(keyy, "savedd");
    //    PlayerPrefs.SetInt(keyLv, lv);
    //}
    //public void Load()
    //{
    //    string keyy = keyLv + IDD.ToString();
    //    string statuss = PlayerPrefs.GetString(keyy);

    //    //if (statuss.Equals("savedd"))
    //    //{
    //    //    //LoadNextScene();
    //    //    //LoadStartScene();
    //    //    ResetPrefabs();
    //    //}
    //}
    private void Load()
    {
        PlayerPrefs.GetInt(keyLv, 0);
    }
    private void Save()
    {
        PlayerPrefs.SetInt(keyLv, lv);
    }

}
