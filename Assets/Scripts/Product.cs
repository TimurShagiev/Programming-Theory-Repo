using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public int price;
    public string productTag;
    public string productName;

    private PlayerCursor playerCursor;
    // Start is called before the first frame update
    void Start()
    {
        playerCursor = GameObject.Find("Main Camera").GetComponent<PlayerCursor>();
        productTag = gameObject.tag;
        productName = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
    }

    
}
