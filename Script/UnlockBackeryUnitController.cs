using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBackeryUnitController : MonoBehaviour
{
    [SerializeField] private ProductType productType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public ProductType GetNeededProductType()// pastane bizden gangi ürünleri bekliyor
    {
        return productType;
    }
    /*public bool StoreProduct()
    {
        return true;
    }*/
}
