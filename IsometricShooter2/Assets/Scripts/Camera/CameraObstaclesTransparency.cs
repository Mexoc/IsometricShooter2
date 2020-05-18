using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraObstaclesTransparency : MonoBehaviour
{
    private GameObject player;
    private Color rayHitObjectColor;
    private List<GameObject> environments = new List<GameObject>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CameraObstaclesTransparent();
    }

    private void CameraObstaclesTransparent()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 100));
        RaycastHit hit;
        GameObject temp;
        Physics.Raycast(ray, out hit);
        temp = hit.collider.gameObject;
        if (temp.tag != "Environment" )
        {
            if (environments == null)
            {
                return;
            }
            else
            {
                foreach (GameObject obj in environments)
                {
                    rayHitObjectColor = obj.GetComponent<MeshRenderer>().material.color;
                    rayHitObjectColor.a = 1;
                    obj.GetComponent<MeshRenderer>().material.color = rayHitObjectColor;
                }
            }
        }
        else
        {
            environments.Add(temp);
            rayHitObjectColor = temp.GetComponent<MeshRenderer>().material.color;
            rayHitObjectColor.a = 0.25f;
            temp.GetComponent<MeshRenderer>().material.color = rayHitObjectColor;
        }
    }
}
