using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapToggle : MonoBehaviour
{
    private GameObject map;

    void Start()
    {
        map = GameObject.Find("map");
        map.SetActive(false);
    }

    void Update()
    {
        ToggleMap();
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
}
