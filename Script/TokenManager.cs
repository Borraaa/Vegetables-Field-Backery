using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    public static TokenManager instance;
    private int token;

    private string keyToken = "keyToken";
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
    // Start is called before the first frame update
    void Start()
    {
        LoadToken();
        DisplayToken();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToken(int priceee)
    {
        token += priceee;
        DisplayToken();
    }
    public int GetRewordedToken()
    {
        return token;
    }
    
    public void DisplayToken()
    {
        UIManager.instance.ShowTokenCalculaterOnScreen(token);
        SaveToken();
    }
    private void LoadToken()
    {
        token = PlayerPrefs.GetInt(keyToken, 0);
    }
    private void SaveToken()
    {
        PlayerPrefs.SetInt(keyToken, token);
    }
}
