using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{

    public GameObject priceTable;
    public int amountofstorage;
    public int[] id;
    public string[] productName;
    public int[] count;
    public int[] sellingPrice;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < amountofstorage; i++)
        {
            sellingPrice[i] = priceTable.GetComponent<Pricetable>().sellingPrice[id[i]];
        }
    }
}
