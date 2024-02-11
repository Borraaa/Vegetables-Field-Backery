using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager instance;
    private int coins;
    
    private string keyCoins = "keyCoins";
    // Start is called before the first frame update

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

    //cash manager a para eklenece�i addcoin �a��r�l�cak zaman �r�n�n miktar� price diyicez onu coins e ekleyecek. biz bagcontrollerde shoppoint i�erisinde yani d�kkana girersek �r�nleri satmak i�in bagcontroller i�erisinde shoppoint �al���yordu orada �r�n satt���m�z cashmanagere s�ylemeliyiz ki chasmanager daki tuttu�u paralar�m�z arts�n chasmanager da UImanager a paralar artt� ekrana g�ster
    public void ExcahangeProduct(ProductData productData)
    {
        AddCoin(productData.productPrice);
    }
    public void AddCoin(int price)
    {
        coins += price;
        GameManager.instance.DisplayMoney();
        //TokenManager.instance.DisplayToken();
        DisplayCoins();
    }
    

    private void SpendCoin(int price)
    {
        coins -= price;
        DisplayCoins();
    }
    public bool TryButThisUnit(int price)
    {
        if (GetCoin() >= price)
        {
            SpendCoin(price);
            return true;
        }
        return false;
    }

    void Start()
    {
       
        
        LoadCash();
        
        DisplayCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetCoin()
    {
        return coins;
    }
    
    private void DisplayCoins()
    {
        UIManager.instance.ShowCoinCountOnScreen(coins);
        
        SaveCash();
    }
    
    private void LoadCash()
    {
       coins = PlayerPrefs.GetInt(keyCoins, 0);
    }
    private void SaveCash()
    {
        PlayerPrefs.SetInt(keyCoins, coins);
    }
    
}
