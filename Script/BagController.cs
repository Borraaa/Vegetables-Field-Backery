using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagController : MonoBehaviour
{
    [SerializeField] private Transform bag; // çantayý player a tanýtmamaýz gerekiyor. küpler çanya konulucak 
    public List<ProductData> productDataList;
    private Vector3 productSize;
    [SerializeField] TextMeshPro maxText;
    int maxBagCapasity;
    // Start is called before the first frame update
    void Start()
    {
        maxBagCapasity = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) // çarpýþma algýlandý
    {
        /*if (other.CompareTag("ShopPoint"))
        {
            UnlockBackeryUnitController bakeryUnit = other.GetComponent<UnlockBackeryUnitController>();
            ProductType neededType = bakeryUnit.GetNeededProductType();
            for (int i = productDataList.Count - 1; i >= 0 ; i--)//karakterin sýrtýndakileri tersten siralar.ve silme iþlemide olduðu için tersten siler yani en tepeden aþaðýya doðru siler
            {
                SellProductToShop(productDataList[i]);
                Destroy(bag.transform.GetChild(i).gameObject); ;//karakterin sýrtýndaki objeleri tersten yok eder. yani çantanýn çocuk objelerini al
                productDataList.RemoveAt(i);// karakterin sýrtýndaki eþyalar silinecek ama objeler productdatalistte hep. çünkü sayýsýný productdatalistte tutuyoruz bundan dolayý buradanda silmemiz gerekiyor. yoksa hiçbir zaman kaç tane objemiz olduðunu anlayamayýz. 
            }
            ControllerBagCapacity();// buradada ürünleri kontrol etmesinin sebebi bu fonksyon ürünleri yok ediyor yok ettikten sonra dolumu boþ mu diye kontrol ediyor
        }*/

        if (other.CompareTag("UnlockBakeryUnit"))
        {
            PlayShopSound();
            UnlockBackeryUnitController bakeryUnit = other.GetComponent<UnlockBackeryUnitController>();
            ProductType neededType = bakeryUnit.GetNeededProductType();
            for (int i = productDataList.Count - 1; i >= 0 ; i--)
            {
                if (productDataList[i].productType == neededType)
                {
                    SellProductToShop(productDataList[i]);
                    //if (bakeryUnit.StoreProduct() == true)
                    //{
                        Destroy(bag.transform.GetChild(i).gameObject);
                        productDataList.RemoveAt(i);
                    //}
                }
            }
            StartCoroutine(PutProductsInOrder());
            ControllerBagCapacity();// buradada ürünleri kontrol etmesinin sebebi bu fonksyon ürünleri yok ediyor yok ettikten sonra dolumu boþ mu diye kontrol ediyor
        }

        if (other.CompareTag("ShopPoint"))
        {
            PlayShopSound();
            UnlockBackeryUnitController bakeryUnit = other.GetComponent<UnlockBackeryUnitController>();
            ProductType neededType = bakeryUnit.GetNeededProductType();
            for (int i = productDataList.Count - 1; i >= 0; i--)
            {
                if (productDataList[i].productType == neededType)
                {
                    SellProductToShop(productDataList[i]);
                    //if (bakeryUnit.StoreProduct() == true)
                    //{
                        Destroy(bag.transform.GetChild(i).gameObject);
                        productDataList.RemoveAt(i);
                    //}
                }
            }
            StartCoroutine(PutProductsInOrder());
            ControllerBagCapacity();// buradada ürünleri kontrol etmesinin sebebi bu fonksyon ürünleri yok ediyor yok ettikten sonra dolumu boþ mu diye kontrol ediyor
        }

    }
    private void SellProductToShop(ProductData productData)
    {

        CashManager.instance.ExcahangeProduct(productData);
    }

    public void AddProductToBag(ProductData productData) // nesne tagý ýle algýlandý arkaya atýlacak.
    {
        if (!IsEmptySpace()) // eðer çantada yer yoksa 
        {
            return;
        }
        GameObject boxProduct = Instantiate(productData.productPrefab, Vector3.zero , Quaternion.identity); //bir þeyi klonlayarak yaratmak için kullanýlýr ýnstantiete, Instantiate(cube, Vector3.zero, Quaternion.identity); //bir þeyi klonlamak ve yaratmak için kullanýlan method 3 parametre ister(orjinal klonlancak obje, pozisyonu , dönme deðeri). quternion.identity defoult deðerdir yani dönme deðeri yok.
        boxProduct.transform.SetParent(bag, true); // parantez içindeki objenin içine child atanacak yani bag ýn içine cube gelicek.
        // instantiete yaptýðýmýzda küp playerýn önüne geldi
        CalculateObjectSize(boxProduct);
        float yPosition = CalculateNewYPositionOfBox();
        boxProduct.transform.localRotation = Quaternion.identity; // dönme deðeri olamayacak 0
        boxProduct.transform.localPosition = Vector3.zero; // pozisyonunu deðiþmeyeceði için 0 ladýk
        boxProduct.transform.localPosition = new Vector3(0, yPosition, 0);
        productDataList.Add(productData); // list oluþturup boxProduct u listeye attýk
        ControllerBagCapacity();
    }
    private float CalculateNewYPositionOfBox() // kutunun yeni y pozisyonunu hesapla. kutu geldðinde arkada yukarý y pozisyonuna doðru yüklenicek
    {
        // ürünün sahnedeki yüksekliði * ürün adedi.
        float newYPos = productSize.y * productDataList.Count; //  ürünün sahnedeki yüksekliði productsize * listenin cound u 
        return newYPos;
    }
    private void CalculateObjectSize(GameObject gameObject)// içerisine oyun objesini vermemiz lazým çünkü objenin meshrendererine eriþiceðiz
    {
        // ürünün mashranderer i olmasii gerekiyor meshranderer in yüksekliðini bulursak ürünün sahnedeki kapladýðý yükseklikte bulunur
        if (productSize == Vector3.zero)// sürekli sürekli hesaplamamýsý için if in içinde yaptýk. ürün en baþta posizyonleýnýn hepsi 0 olduðu için vector3.zero dedik. 
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();// meshrendererini aldýk
            productSize = renderer.bounds.size; // ürünün yüksekliði hesaplandý be productsize a atýldý.
        }
         

    }
    private void ControllerBagCapacity()
    {
        if (productDataList.Count == maxBagCapasity)
        {
            SetMaxTextOn();
        }
        else
        {
            SetMaxTextOff();
        }
    }
    private void SetMaxTextOn()
    {
        if (!maxText.isActiveAndEnabled)
        {
            maxText.gameObject.SetActive(true);
        }
    }
    private void SetMaxTextOff()
    {
        if (maxText.isActiveAndEnabled)
        {
            maxText.gameObject.SetActive(false);
        }
    }
    public bool IsEmptySpace()
    {
        if (productDataList.Count < maxBagCapasity)
        {
            return true;
        }
        return false;
    }
    private IEnumerator PutProductsInOrder()
    {
        yield return new WaitForSeconds(0.15f);
        for (int i = 0; i < bag.childCount; i++)
        {
            float newYPos = productSize.y * i;
            bag.GetChild(i).transform.localPosition = new Vector3(0, newYPos, 0);   
        }
    }
    private void PlayShopSound()
    {
        if (productDataList.Count > 0)
        {
            AudioManager.instance.PlayAudio(AudioClipType.shopClip);
        }
    }
}
