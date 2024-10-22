using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Alcohol : Product
{

    public ParticleSystem bubbles;
    public PlayerCursor playerCursor;

    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        posOffset = transform.position;
        playerCursor = GameObject.Find("Main Camera").GetComponent<PlayerCursor>();
        bubbles = GetComponentInChildren<ParticleSystem>();
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
            if (!isPlaying)
            {
                bubbles.Play();
                isPlaying = true;
            }
        } else
        {
            isPlaying = false;
            bubbles.Stop();
        }
    }
}
