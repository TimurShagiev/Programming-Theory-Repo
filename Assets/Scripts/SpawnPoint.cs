using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private List<GameObject> products = new List<GameObject>();
    // Start is called before the first frame update

    public void SpawnProduct()
    {
        int index = Random.Range(0, products.Count);
        if (products[index].name == "Bottle")
        {
            Instantiate(products[index], transform.position + new Vector3(0, 0.3f, 0), transform.rotation);
        } else
        {
            Instantiate(products[index], transform.position, transform.rotation);
        }

    }
}
