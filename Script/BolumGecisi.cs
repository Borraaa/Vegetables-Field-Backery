using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolumGecisi : MonoBehaviour
{
    //private Vector3 baslangicPozisyonu;
    //private Quaternion baslangicRotasyon;
    //private Vector3 baslangicOlcegi;

    //void Start()
    //{
    //    // Nesnenin ba�lang�� pozisyonunu, rotasyonunu ve �l�e�ini kaydet
    //    baslangicPozisyonu = transform.position;
    //    baslangicRotasyon = transform.rotation;
    //    baslangicOlcegi = transform.localScale;
    //    YeniBolum();
    //}

    //public void YeniBolum()
    //{
    //    transform.position = baslangicPozisyonu;
    //    transform.rotation = baslangicRotasyon;
    //    transform.localScale = baslangicOlcegi;
    //}
    
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("NextLevel"))
    //    {
            
    //        YeniBolum(); // Yeni b�l�m� olu�tur ve prefablar� ayarla
    //    }
    //}


    //void TemizleEskiBolum()
    //{
    //    // Eski b�l�mdeki nesneleri yok et
    //    GameObject[] eskiNesneler = GameObject.FindGameObjectsWithTag("TomatoField");
    //    foreach (GameObject nesne in eskiNesneler)
    //    {
    //        Destroy(nesne); // Nesneleri yok et
    //    }
    //}
    //void YeniBolumuOlustur()
    //{
    //    // Yeni b�l�mdeki nesneleri olu�tur
    //    GameObject yeniBolum = Instantiate(yeniBolumPrefab, yeniBolumPozisyonu, Quaternion.identity);

    //    // Yeni prefablar� kapal� veya gizli bir durumda ayarla
    //    MeshRenderer[] meshRenderers = yeniBolum.GetComponentsInChildren<MeshRenderer>();
    //    foreach (MeshRenderer renderer in meshRenderers)
    //    {
    //        renderer.enabled = false; // MeshRendereri kapat
    //    }
    //}
}
