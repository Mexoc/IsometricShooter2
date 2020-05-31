using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorStats: MonoBehaviour
{
    public Vector3 doorOpenCoord;
    public Vector3 doorClosedCoord;
    public bool isDoorOpen;

    private void Start()
    {
        doorClosedCoord = gameObject.transform.position;
        doorOpenCoord = new Vector3(gameObject.transform.position.x, 393.3f, gameObject.transform.position.z);
        isDoorOpen = false;
    }
}
