using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstaclesTransparency : MonoBehaviour
{
    private GameObject player;
    private Color rayHitObjectColor;
    private GameObject[] environments;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (environments == null)
        {
            environments = GameObject.FindGameObjectsWithTag("Environment");
        }
        CameraObstaclesTransparent();
    }

    private void CameraObstaclesTransparent()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 100));
        RaycastHit hit;
        GameObject temp;
        Physics.Raycast(ray, out hit);
        temp = hit.collider.gameObject;
        if (temp.tag == "Environment")
        {
            rayHitObjectColor = temp.GetComponent<Renderer>().material.color;
            rayHitObjectColor.a = 0;
            temp.GetComponent<Renderer>().material.color = rayHitObjectColor;
        }
        else
        {
            foreach (GameObject obj in environments)
            {
                rayHitObjectColor = obj.GetComponent<Renderer>().material.color;
                rayHitObjectColor.a = 1;
                obj.GetComponent<Renderer>().material.color = rayHitObjectColor;
            }
        }
    }
}
