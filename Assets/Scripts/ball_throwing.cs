using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ball_throwing : MonoBehaviour
{
    public Rigidbody ball;
    public Image PowerBarMask;
    public bool isGrabbed = false;
    public float currentPower = 0;
    public float maxPower = 10;
    public float barChangeSpeed = 0.1f;
    public bool powerIsIncreasing = false;
    public XRRayInteractor rayInteractor;

    public void grabbed()
    {
        
        isGrabbed = true;
        StartCoroutine(UpdatePower());
        rayInteractor.lineType = XRRayInteractor.LineType.ProjectileCurve;
    }

    public void throwed()
    {
        isGrabbed = false;
        rayInteractor.lineType = XRRayInteractor.LineType.StraightLine;
    }

    IEnumerator UpdatePower()
    {
        while (isGrabbed)
        {
            if (!powerIsIncreasing)
            {
                currentPower -= barChangeSpeed;
                if (currentPower <= 0)
                {
                    powerIsIncreasing = true;
                }
            }
            if (powerIsIncreasing)
            {
                currentPower += barChangeSpeed;
                print(currentPower);
                if (currentPower >= maxPower)
                {
                    powerIsIncreasing = false;
                }
            }
            float fill = currentPower / maxPower;
            PowerBarMask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);
        }

        Vector3 f = transform.forward;
        float impulseFactor = currentPower;
        f.x *= impulseFactor;
        f.y *= impulseFactor;
        f.z *= impulseFactor;
        ball.AddForce(f, ForceMode.Impulse);

        currentPower = 0;
        PowerBarMask.fillAmount = currentPower;

        yield return null;
    }

    private void Update()
    {
        DebugConsole.instance.log("test");
    }

}
