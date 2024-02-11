using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductPlantController : MonoBehaviour
{
    private bool isReadyToPick;
    private Vector3 orgnalScale;
    [SerializeField] ProductData productData;
    private BagController bagController;
    
    // Start is called before the first frame update
    void Start()
    {
        isReadyToPick = true;
        orgnalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && isReadyToPick)
        {
            bagController = other.GetComponent<BagController>(); // player objesine component olarak ekledik sebebi bagcontrol scriptine eriþebilmek bagcontroldaki 
            if (bagController.IsEmptySpace())
            {
                AudioManager.instance.PlayAudio(AudioClipType.grapClip);
                bagController.AddProductToBag(productData);
                isReadyToPick = false;


                StartCoroutine(ProductsPicked());
            }
            
        }
    }
    IEnumerator ProductsPicked()
    {
        Vector3 targetScale = orgnalScale / 3;
        transform.gameObject.LeanScale(targetScale, 1f).setEase(LeanTweenType.easeOutBack); ;

        yield return new WaitForSeconds(5f);

        transform.gameObject.LeanScale(orgnalScale, 1f).setEase(LeanTweenType.easeOutBack); ;
        isReadyToPick = true;
    }


    /*IEnumerator ProductsPicked()
    {
        float duration = 1f;
        float timer = 0;
        Vector3 targetScale = orgnalScale/3;
        while(timer < duration)
        {
            float t = timer / duration;
            Vector3 newScale = Vector3.Lerp(orgnalScale, targetScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;

        }
        yield return new WaitForSeconds(5f);

        timer = 0;
        float büyüme = 1f;
        while (timer < büyüme)
        {
            float t = timer / büyüme;
            Vector3 newScale = Vector3.Lerp(targetScale, orgnalScale, t);
            transform.localScale = newScale;
            timer += Time.deltaTime;
            yield return null;
        }
        isReadyToPick=true;
        yield return null;
    }*/
}
