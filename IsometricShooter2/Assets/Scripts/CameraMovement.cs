using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject player;
    private Vector3 playerPos;
    private Vector3 mainCameraPos;
    private Vector3 cameraCenter = new Vector3(-35, 50, -35);
    private Quaternion cameraRotation = Quaternion.Euler(45, 45, 0);

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CameraUpdate();
    }

    private void CameraUpdate()
    {
        playerPos = player.transform.position;
        mainCameraPos = playerPos + cameraCenter;
        mainCamera.transform.rotation = cameraRotation;
        mainCamera.transform.position = mainCameraPos;
    }
}
