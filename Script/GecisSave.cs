using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GecisSave : MonoBehaviour
{
    public static GecisSave instance;   

    private string levelKey = "PlayerLevel";
    private int currentLevel;

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
        
    }
    public void OnApplicationQuit()
    {
        SaveGame();
        // Oyun kapat�ld���nda ilerlemeyi kaydetme
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt(levelKey, currentLevel);
        PlayerPrefs.Save();
    }
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey(levelKey))
        {
            currentLevel = PlayerPrefs.GetInt(levelKey);
            // Kaydedilmi� seviyeyi y�kleme
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
