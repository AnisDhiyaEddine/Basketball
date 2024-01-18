using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayMenu : MonoBehaviour
{
    public GameObject menuCanvas;
    public bool playing = true;

    public void ToggleMenu()
    {
        if (menuCanvas != null)
        {
            // Basculez l'état actif / désactivé du menu.
            menuCanvas.SetActive(!menuCanvas.activeSelf);

            if (menuCanvas.activeSelf)
            {
                // Orientez le menu vers la caméra.
                if (Camera.main != null)
                {
                    menuCanvas.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3;
                    menuCanvas.transform.rotation = Quaternion.LookRotation(menuCanvas.transform.position - Camera.main.transform.position);
                }
                else
                {
                    Debug.LogError("Main camera not found. Make sure your camera is tagged as 'MainCamera'.");
                }
            }
        }
    }
}
