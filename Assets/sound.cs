using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public AudioSource src;
    public AudioClip shoutingSrc, hitSrc, passSrc, almostSrc;

    public void shout()
    {
        src.clip = shoutingSrc;
        src.Play();
    }


    public void hit()
    {
        src.clip = hitSrc;
        src.Play();
    }
    public void pass()
    {
        src.clip = passSrc;
        src.Play();
    }

    public void almost()
    {
        src.clip = almostSrc;
        src.Play();
    }

}
