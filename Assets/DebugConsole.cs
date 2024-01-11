using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    public static DebugConsole instance;

    [SerializeField] RectTransform displayRect;
    [SerializeField] Text displayText;
    float initHeight;

    void Awake()
    {
        if(DebugConsole.instance != null)
        {
            DestroyImmediate(gameObject);
        } else
        {
            DebugConsole.instance = this;
        }

        initHeight = displayRect.anchoredPosition.y;
    }

    public void changeDisplayPosition(float newPos)
    {
        displayRect.anchoredPosition = new Vector2(displayRect.anchoredPosition.x, initHeight + newPos);
    }

    public void log(string newLog)
    {
        displayText.text = newLog + "\n" + displayText.text;
    }

    public void logWarning(string newLog)
    {
        displayText.text = "Warning: " +  newLog + "\n" + displayText.text;
    }

    public void logError(string newLog)
    {
        displayText.text = "Error: " + newLog + "\n" + displayText.text;
    }
}
