using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugConsole : MonoBehaviour
{
    public static DebugConsole instance;
    [SerializeField] Text displayText;


    void Awake()
    {
        if (DebugConsole.instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DebugConsole.instance = this;
        }

    }

    public void log(string newLog)
    {
        displayText.text = "["+ DateTime.Now.ToString("HH: mm:ss") + "] " + newLog + "\n"+ displayText.text;
    }

    public void logWarning(string newLog)
    {
        displayText.text = "["+ DateTime.Now.ToString("HH: mm:ss") + "] Warning: " + newLog + "\n" + displayText.text;
    }

    public void logError(string newLog)
    {
        displayText.text = "[" + DateTime.Now.ToString("HH: mm:ss") + "] Error: " + newLog + "\n" + displayText.text;
    }
}