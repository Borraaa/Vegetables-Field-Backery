using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagController : MonoBehaviour
{
    [SerializeField] private Transform bag; // �antay� player a tan�tmama�z gerekiyor. k�pler �anya konulucak 
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
    private void OnTriggerEnter(Collider other) // �arp��ma alg�land�
    {
        /*if (other.CompareTag("ShopPoint"))
        {
            UnlockBackeryUnitController bakeryUnit = other.GetComponent<UnlockBackeryUnitController>();
            ProductType neededType = bakeryUnit.GetNeededProductType();
            for (int i = productDataList.Count - 1; i >= 0 ; i--)//karakterin s�rt�ndakileri tersten siralar.ve silme i�lemide oldu�u i�in tersten siler yani en tepeden a�a��ya do�ru siler
            {
                SellProductToShop(productDataList[i]);
                Destroy(bag.transform.GetChild(i).gameObject); ;//karakterin s�rt�ndaki objeleri tersten yok eder. yani �antan�n �ocuk objelerini al
                productDataList.RemoveAt(i);// karakterin s�rt�ndaki e�yalar silinecek ama objeler productdatalistte hep. ��nk� say�s�n� productdatalistte tutuyoruz bundan dolay� buradanda silmemiz gerekiyor. yoksa hi�bir zaman ka� tane objemiz oldu�unu anlayamay�z. 
            }
            ControllerBagCapacity();// buradada �r�nleri kontrol etmesinin sebebi bu fonksyon �r�nleri yok ediyor yok ettikten sonra dolumu bo� mu diye kontrol ediyor
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
            ControllerBagCapacity();// buradada �r�nleri kontrol etmesinin sebebi bu fonksyon �r�nleri yok ediyor yok ettikten sonra dolumu bo� mu diye kontrol ediyor
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
            ControllerBagCapacity();// buradada �r�nleri kontrol etmesinin sebebi bu fonksyon �r�nleri yok ediyor yok ettikten sonra dolumu bo� mu diye kontrol ediyor
        }

    }
    private void SellProductToShop(ProductData productData)
    {

        CashManager.instance.ExcahangeProduct(productData);
    }

    public void AddProductToBag(ProductData productData) // nesne tag� �le alg�land� arkaya at�lacak.
    {
        if (!IsEmptySpace()) // e�er �antada yer yoksa 
        {
            return;
        }
        GameObject boxProduct = Instantiate(productData.productPrefab, Vector3.zero , Quaternion.identity); //bir �eyi klonlayarak yaratmak i�in kullan�l�r �nstantiete, Instantiate(cube, Vector3.zero, Quaternion.identity); //bir �eyi klonlamak ve yaratmak i�in kullan�lan method 3 parametre ister(orjinal klonlancak obje, pozisyonu , d�nme de�eri). quternion.identity defoult de�erdir yani d�nme de�eri yok.
        boxProduct.transform.SetParent(bag, true); // parantez i�indeki objenin i�ine child atanacak yani bag �n i�ine cube gelicek.
        // instantiete yapt���m�zda k�p player�n �n�ne geldi
        CalculateObjectSize(boxProduct);
        float yPosition = CalculateNewYPositionOfBox();
        boxProduct.transform.localRotation = Quaternion.identity; // d�nme de�eri olamayacak 0
        boxProduct.transform.localPosition = Vector3.zero; // pozisyonunu de�i�meyece�i i�in 0 lad�k
        boxProduct.transform.localPosition = new Vector3(0, yPosition, 0);
        productDataList.Add(productData); // list olu�turup boxProduct u listeye att�k
        ControllerBagCapacity();
    }
    private float CalculateNewYPositionOfBox() // kutunun yeni y pozisyonunu hesapla. kutu geld�inde arkada yukar� y pozisyonuna do�ru y�klenicek
    {
        // �r�n�n sahnedeki y�ksekli�i * �r�n adedi.
        float newYPos = productSize.y * productDataList.Count; //  �r�n�n sahnedeki y�ksekli�i productsize * listenin cound u 
        return newYPos;
    }
    private void CalculateObjectSize(GameObject gameObject)// i�erisine oyun objesini vermemiz laz�m ��nk� objenin meshrendererine eri�ice�iz
    {
        // �r�n�n mashranderer i olmasii gerekiyor meshranderer in y�ksekli�ini bulursak �r�n�n sahnedeki kaplad��� y�kseklikte bulunur
        if (productSize == Vector3.zero)// s�rekli s�rekli hesaplamam�s� i�in if in i�inde yapt�k. �r�n en ba�ta posizyonle�n�n hepsi 0 oldu�u i�in vector3.zero dedik. 
        {
            MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();// meshrendererini ald�k
            productSize = renderer.bounds.size; // �r�n�n y�ksekli�i hesapland� be productsize a at�ld�.
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
