using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBars : MonoBehaviour
{
    private Canvas enemyHealthBar;
    private GameObject mainCamera;

    private void Awake()
    {
        enemyHealthBar = gameObject.GetComponentInChildren<Canvas>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void Update()
    {
        HealthbarCameraLook();
    }

    private void HealthbarCameraLook()
    {
        enemyHealthBar.transform.LookAt(mainCamera.transform);
    }

}
