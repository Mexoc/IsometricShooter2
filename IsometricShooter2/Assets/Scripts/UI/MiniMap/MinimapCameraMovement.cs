using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapCameraMovement : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject[] minimapIcons;
    private GameObject map;

    private void Start()
    {
        map = GameObject.Find("map");
    }

    void Update()
    {
        MinimapCameraMove();
        MinimapIconsLook();
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
        if (!map.activeSelf)
        {
            foreach (GameObject temp in minimapIcons)
            {
                temp.transform.LookAt(this.gameObject.transform);
            }
        }
        else
        {
            foreach (GameObject temp in minimapIcons)
            {
                temp.transform.LookAt(GameObject.Find("MapCamera").transform);
            }
        }

    }
}
