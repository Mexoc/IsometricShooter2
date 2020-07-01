using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CursorOverUICheck : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;
    private EventSystem eventSystem;
    private List<RaycastResult> raycastResult;
    private PointerEventData pointerEventData;
    private GameObject player;

    void Start()
    {
        graphicRaycaster = gameObject.GetComponent<GraphicRaycaster>();
        eventSystem = GameObject.FindObjectOfType<EventSystem>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CursorShootLockUI();
    }

    public bool CursorRaycastingUI()
    {
        pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = Input.mousePosition;
        raycastResult = new List<RaycastResult>();
        graphicRaycaster.Raycast(pointerEventData, raycastResult);
        foreach (var result in raycastResult)
        {
            if (result.gameObject.layer == 5)
            {
                return true;
            }            
        }
        return false;
    }

    private void CursorShootLockUI()
    {
        if (CursorRaycastingUI())
        {
            player.GetComponent<PlayerStats>().CanPlayerShoot = false;
        }
        else
            player.GetComponent<PlayerStats>().CanPlayerShoot = true;
    }

}
