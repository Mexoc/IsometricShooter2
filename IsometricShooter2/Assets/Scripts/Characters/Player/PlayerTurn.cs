using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private GameObject player;
    public Vector3 mousePoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("PlayerBody");
    }

    private void LateUpdate()
    {
        PlayerCursorLook();
    }

    private void PlayerCursorLook()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {               
                mousePoint = hit.point;
                mousePoint.y = player.transform.position.y;
                player.transform.LookAt(mousePoint);
            }
        }
    }
}
