using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanelUse : MonoBehaviour
{
    private GameObject elevatorDoor;
    private GameObject player;
    private bool canOpenElevatorDoor;

    void Start()
    {
        elevatorDoor = GameObject.FindGameObjectWithTag("ElevatorDoor");
        player = GameObject.FindGameObjectWithTag("Player");
        canOpenElevatorDoor = false;
    }

    private void Update()
    {
        CanOpenElevatorDoor();
    }

    private void OnTriggerStay(Collider other)
    {
        ElevatorDoorToggle();
    }

    private bool CanOpenElevatorDoor()
    {
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerStats>().isKeycardLooted)
        {
            canOpenElevatorDoor = true;
        }
        else
            canOpenElevatorDoor = false;
        return canOpenElevatorDoor;
    }

    private void ElevatorDoorToggle()
    {
        if (CanOpenElevatorDoor())
        {
            if ((elevatorDoor.GetComponent<ElevatorDoorStats>().isDoorOpen == false))
            {
                elevatorDoor.GetComponent<ElevatorDoorStats>().isDoorOpen = true;
                elevatorDoor.transform.position = elevatorDoor.GetComponent<ElevatorDoorStats>().doorOpenCoord;
            }
            else
            {
                elevatorDoor.GetComponent<ElevatorDoorStats>().isDoorOpen = false;
                elevatorDoor.transform.position = elevatorDoor.GetComponent<ElevatorDoorStats>().doorClosedCoord;
            } 

        }
    }
}
