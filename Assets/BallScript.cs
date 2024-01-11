using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    int i = 0;
    void Update()
    {
        i += 1;
        DebugConsole.instance.log("Logging normal " + i);
        DebugConsole.instance.log("Logging warning " + i);
        DebugConsole.instance.log("Logging error " + i);
    }
}
