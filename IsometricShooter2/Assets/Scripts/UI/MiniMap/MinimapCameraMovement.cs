using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMovement : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject[] minimapIcons;

    void Update()
    {
        MinimapCameraMove();
        //MinimapIconsLook();
    }

    private void MinimapCameraMove()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }        
        this.gameObject.transform.position = mainCamera.transform.position;
        this.gameObject.transform.rotation = mainCamera.transform.rotation;
        this.gameObject.GetComponent<Camera>().orthographicSize = 50;
    }

    private void MinimapIconsLook()
    {
        minimapIcons = GameObject.FindGameObjectsWithTag("MiniMap");              
        foreach (GameObject temp in minimapIcons)
        {
            temp.transform.LookAt(gameObject.transform);
        }
                
    }
}
