using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alcohol : Product
{

    ParticleSystem bubbles;
    private PlayerCursor playerCursor;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        playerCursor = GameObject.Find("Main Camera").GetComponent<PlayerCursor>();
        bubbles.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
    }
    public override void Idle()
    {
        base.Idle();
        if (playerCursor.onCursor)
        {
            bubbles.Play();
        } else
        {
            bubbles.Stop();
        }
    }
}
