using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public float price;

    private PlayerCursor playerCursor;
    // Start is called before the first frame update
    void Start()
    {
        playerCursor = GameObject.Find("Main Camera").GetComponent<PlayerCursor>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void getInInventory()
    {
        if (playerCursor.isClicked)
        {
            Destroy(gameObject);
        }
    }
}
