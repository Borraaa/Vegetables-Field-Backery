using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //public UIManager uýManager;
    [SerializeField] private RewordedAds rewordedads;
    [SerializeField] private InderstitialAds inderstitialads;

    

    //[SerializeField] private Vector3 yeniBolumPozisyonu;
    //public GameObject yeniBolumPrefab;
    private int money;
    //private string rewordedcoins = "rewordedcoins";
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
    public void Start()
    {
        //LoadCash();

        CoinCalculator(0);
        DisplayMoney();
        Debug.Log(PlayerPrefs.GetInt("moneyy"));
        //ResetPrefabs();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameObject.CompareTag("NextLevel"))
        {
            //Debug.Log("bitti");
            //CoinCalculator(100);
            rewordedads.LoadRewardedAd();
            inderstitialads.LoadLoadInterstitialAd();


            UlManagerCanvas.instance.FinishScreen();

            //TemizleEskiBolum();
            //YeniBolumuOlustur();

        }
    }

    

    

    public int GetRewordedMoney()
    {
        return money;
    }
    public void CoinCalculator(int pricee)
    {
        money += pricee;
        //CoinCalculator(100);
        DisplayMoney();

        //if (PlayerPrefs.HasKey("moneyy"))
        //{
        //    int oldscore = PlayerPrefs.GetInt("moneyy");
        //    PlayerPrefs.SetInt("moneyy", oldscore + money);
        //}
        //else
        //{
        //    PlayerPrefs.SetInt("moneyy", 0);
        //}
    }
    public void DisplayMoney()
    {
        UIManager.instance.ShowCalculateCoinOnScreen(money);
        //CashManager.SaveCash();
        //SaveCash();
    }
    //private void LoadCash()
    //{
    //    money = PlayerPrefs.GetInt(rewordedcoins, 0);
    //}
    //private void SaveCash()
    //{
    //    PlayerPrefs.SetInt(rewordedcoins, money);
    //}
    //void TemizleEskiBolum()
    //{
    //    // Eski bölümdeki nesneleri yok et
    //    GameObject[] eskiNesneler = GameObject.FindGameObjectsWithTag("TomatoField");
    //    foreach (GameObject nesne in eskiNesneler)
    //    {
    //        Destroy(nesne); // Nesneleri yok et
    //    }
    //}

    //void YeniBolumuOlustur()
    //{
    //    // Yeni bölümdeki nesneleri oluþtur
    //    GameObject yeniBolum = Instantiate(yeniBolumPrefab, yeniBolumPozisyonu, Quaternion.identity);

    //    // Yeni prefablarý kapalý veya gizli bir durumda ayarla
    //    MeshRenderer[] meshRenderers = yeniBolum.GetComponentsInChildren<MeshRenderer>();
    //    foreach (MeshRenderer renderer in meshRenderers)
    //    {
    //        renderer.enabled = false; // MeshRendereri kapat
    //    }
    //}
}
