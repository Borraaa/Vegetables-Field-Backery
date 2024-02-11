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
    //    // Nesnenin baþlangýç pozisyonunu, rotasyonunu ve ölçeðini kaydet
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
            
    //        YeniBolum(); // Yeni bölümü oluþtur ve prefablarý ayarla
    //    }
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
