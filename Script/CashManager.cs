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

    //cash manager a para ekleneceði addcoin çaðýrýlýcak zaman ürünün miktarý price diyicez onu coins e ekleyecek. biz bagcontrollerde shoppoint içerisinde yani dükkana girersek ürünleri satmak için bagcontroller içerisinde shoppoint çalýþýyordu orada ürün sattýðýmýz cashmanagere söylemeliyiz ki chasmanager daki tuttuðu paralarýmýz artsýn chasmanager da UImanager a paralar arttý ekrana göster
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
