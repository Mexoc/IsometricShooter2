using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 mainCameraPos;
    public Vector3 cameraCenter = new Vector3(-35, 50, -35);
    public Quaternion cameraRotation = Quaternion.Euler(45, 45, 0);
    private Color rayHitObjectColor;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CameraUpdate();
        CameraObstaclesTransparency();
    }

    private void CameraUpdate()
    {
        playerPos = player.transform.position;
        mainCameraPos = playerPos + cameraCenter;
        mainCamera.transform.rotation = cameraRotation;
        mainCamera.transform.position = mainCameraPos;
    }

    private void CameraObstaclesTransparency()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 100));
        RaycastHit hit;        
        GameObject temp;
        float distancePlayerCamera;
        float distanceTempCamera;
        Physics.Raycast(ray, out hit);
        distancePlayerCamera = Vector3.Magnitude(player.transform.position - this.gameObject.transform.position);
        distanceTempCamera = Vector3.Magnitude(hit.point - this.gameObject.transform.position);
        temp = hit.collider.gameObject;
        if (temp.tag == "Environment")
        {
            rayHitObjectColor = temp.GetComponent<Renderer>().material.color;
            rayHitObjectColor.a = 0;
            temp.GetComponent<Renderer>().material.color = rayHitObjectColor;            
        }
        Debug.Log("distance from player to camera = " + distancePlayerCamera + "; distance temp = " + distanceTempCamera);
        //Debug.Log(temp.tag);
    }
}
