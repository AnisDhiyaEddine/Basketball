using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    public AudioSource src;
    public AudioClip shoutingSrc, hitSrc, almostSrc;

    void Start()
    {

    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            src.clip = hitSrc;
            src.Play();
        }

        if (collision.gameObject.name == "hoop")
        {
            src.clip = almostSrc;
            src.Play();
        }

    }


    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {

    }
}
