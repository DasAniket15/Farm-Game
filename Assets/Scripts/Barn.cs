using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public GameObject priceTable;
    public int amountOfStorage;
    public int[] id;
    public string[] productName;
    public int[] count;
    public int[] sellingPrice;

    void Update()
    {
        if (amountOfStorage > 0 && id.Length == amountOfStorage && sellingPrice.Length == amountOfStorage)
        {
            for (int i = 0; i < amountOfStorage; i++)
            {
                sellingPrice[i] = priceTable.GetComponent<PriceTable>().sellingPrice[id[i]];
            }
        }
    }
}
