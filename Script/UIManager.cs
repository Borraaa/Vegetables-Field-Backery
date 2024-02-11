using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI coinCountText;
    [SerializeField] private TextMeshPro coinText;
    [SerializeField] private TextMeshProUGUI tokenCountText;
    //[SerializeField] private int IDD;
    //private int lv;
    //private string keyLv = "keyLv";
    

    //[SerializeField] private TextMeshProUGUI CoinText;

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
        
        //LoadLv();
    }



    // Update is called once per frame
    void Update()
    {
        
    }















    //public void RestartScene()
    //{
    //    //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    int sceneIndex = SceneManager.GetActiveScene().buildIndex;
    //    //int currentSceneIndexx = SceneManager.GetActiveScene().buildIndex;
    //    //SceneManager.LoadScene(currentSceneIndexx);
    //    //LoadLv();
    //    SaveLv();
    //}

    //private void LoadLv()
    //{

    //    string keyy = keyLv + IDD.ToString();
    //    string statuss = PlayerPrefs.GetString(keyy);

    //    if (statuss.Equals("savedd"))
    //    {
    //        //RestartScene();
    //        LoadNextScene();
    //        //LoadStartScene();
    //    }


    //    //lv = PlayerPrefs.GetInt(keyLv, 0);
    //}
    //private void SaveLv()
    //{
    //    string keyy = keyLv + IDD.ToString();
    //    PlayerPrefs.SetString(keyy, "savedd");

    //    //PlayerPrefs.SetInt(keyLv, lv);
    //}

    

    public void ShowCoinCountOnScreen(int coins)
    {
        coinCountText.text = coins.ToString();

    }
    public void ShowCalculateCoinOnScreen(int money)
    {
        coinText.text = money.ToString();
    }
    public void ShowTokenCalculaterOnScreen(int token)
    {
        tokenCountText.text = token.ToString();
    }
}
