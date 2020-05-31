using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

public class MapToggle : MonoBehaviour
{
    private GameObject map;
    private GameObject minimapCamera;
    private GameObject[] minimapIcons;

    private void Awake()
    {
        map = GameObject.FindGameObjectWithTag("UILevelMap");
        minimapIcons = GameObject.FindGameObjectsWithTag("MiniMap");
        minimapCamera = GameObject.Find("minimapCamera");
    }

    void Start()
    {
        map.SetActive(false);
    }

    void Update()
    {
        ToggleMap();
        MiniMapIconsLook();
    }

    private void ToggleMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (map.activeSelf == false)
            {
                map.SetActive(true);
            }
            else
                map.SetActive(false);
        }
    }

    private void MiniMapIconsLook()
    {
        if (map.activeSelf == false)
        {
            foreach (GameObject obj in minimapIcons)
            {
                obj.transform.LookAt(minimapCamera.transform);
            }
        }
        else
        {
            foreach (GameObject obj in minimapIcons)
            {
                obj.transform.LookAt(gameObject.transform);
            }
        }
    }
}
