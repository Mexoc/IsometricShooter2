using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    private GameObject player;

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
                var temp = hit.point;
                temp.y = player.transform.position.y;
                player.transform.LookAt(temp);
            }
        }
    }
}
