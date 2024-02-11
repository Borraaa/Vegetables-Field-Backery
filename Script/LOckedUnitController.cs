using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class LOckedUnitController : MonoBehaviour
{
    public static LOckedUnitController instance;
    [Header("Settings")]
    [SerializeField] private int price;
    //[SerializeField] private int ID;

    [Header("Object")]
    [SerializeField] private TextMeshPro priceText;
    [SerializeField] private GameObject locketUnit;
    [SerializeField] private GameObject unLocketUnit;

    //[SerializeField] private GameObject myprefab;
    private bool isPurchaset;

    //private string keyUnit = "keyUnit";

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
        priceText.text = price.ToString();
         //LoadUnit();
        // ResetPrefabs();      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPurchaset)
        {
            UnLockUnit();
        }
    }
    private void UnLockUnit()
    {
        if (CashManager.instance.TryButThisUnit(price))
        {
            AudioManager.instance.PlayAudio(AudioClipType.shopClip);
            UnLuck();
            //SaveUnit();
        }
    }
    private void UnLuck() 
    { 
        isPurchaset = true;    
        locketUnit.SetActive(false);
        unLocketUnit.SetActive(true);
        //Instantiate(myprefab, new Vector3(0, 0, 0), Quaternion.identity).SetActive(false);
    }
    //public void ResetPrefabs()
    //{
    //    // Sahnedeki tüm GameObject'leri al
    //    GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

    //    // Her GameObject'i yeniden baþlat
    //    foreach (GameObject obj in allObjects)
    //    {
    //        // Eðer GameObject bir prefab ise
    //        if (PrefabUtility.GetPrefabAssetType(obj) == PrefabAssetType.Regular)
    //        {
    //            // GameObject'i yeniden baþlat
    //            PrefabUtility.ResetToPrefabState(obj);
    //        }
    //    }
    //}
    //private void SaveUnit()
    //{
    //    string key = keyUnit + ID.ToString();
    //    PlayerPrefs.SetString(key, "saved");
    //}
    //private void LoadUnit()
    //{
    //    string key = keyUnit + ID.ToString();
    //    string status = PlayerPrefs.GetString(key);
    //    if (status.Equals("saved"))
    //    {
    //        UnLuck();
    //    }
    //}
}
