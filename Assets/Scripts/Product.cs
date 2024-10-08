using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    public float price;
    protected float rotationSpeed = 40.0f;
    protected float amplitude = 0.1f;
    protected float frequency = 1f;

    public bool isAllowed = true;

    protected Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();


    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
    }

    public virtual void Idle()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);

        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * -amplitude;

        transform.position = tempPos;
    }
}
