using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public int id;
    public GameObject crops;

    void Start()
    {
        id = Product.whichSeed;

        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);

        GameObject newCrops = Instantiate(crops, transform.position,  transform.rotation);
        newCrops.GetComponent<Crop>().id = id;
        Destroy(this.gameObject);
    }
}
