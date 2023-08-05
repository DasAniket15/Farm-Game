using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour
{

    public int id;

    public GameObject crops;
    // Start is called before the first frame update
    void Start()
    {
        id = Product.whichseed;

        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);

        GameObject newCrops = Instantiate(crops, transform.position,  transform.rotation);
        newCrops.GetComponent<crop>().id = id;
        Destroy(this.gameObject);
    }
}
