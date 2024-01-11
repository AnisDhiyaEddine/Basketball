using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ball_throwing : MonoBehaviour
{
    public Rigidbody ball;
    public Image PowerBarMask;
    public bool isGrabbed = false;
    public float currentPower;
    public float maxPower = 50;
    public bool powerBarOn;
    public float barChangeSpeed = 1;
    public bool powerIsIncreasing = false;
    public float impulseFactor = 10;


    void Start()
    {
        currentPower = 0;
        powerBarOn = true;
        
    }

    public void grabbed()
    {
        isGrabbed = true;
        StartCoroutine(UpdatePower());
    }

   public void throwed()
    {
        isGrabbed = false;
    }

    IEnumerator UpdatePower()
    {
        while (isGrabbed)
        {
            if (!powerIsIncreasing)
            {
                currentPower -= barChangeSpeed;
                if(currentPower <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if(powerIsIncreasing)
            {
                currentPower += barChangeSpeed;
                print(currentPower);
                if(currentPower >= maxPower)
                {
                    powerIsIncreasing = false;
                }
            }
            float fill = currentPower / maxPower;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);
        }

        Vector3 f = transform.forward;
        f.x *= impulseFactor;
        f.y *= impulseFactor;
        f.z *= impulseFactor;
        ball.AddForce(f, ForceMode.Impulse);

        currentPower = 0;
        PowerBarMask.fillAmount = currentPower;

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isGrabbed)
        {
            flag.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else
        {
            flag.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }*/
    }
}
