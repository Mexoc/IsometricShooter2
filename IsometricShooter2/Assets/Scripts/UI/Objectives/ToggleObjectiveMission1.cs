using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleObjectiveMission1 : MonoBehaviour
{
    private GameObject objectiveUI;
    private Text objectiveText;
    private GameObject player;
    private bool isElevatorDoorOpen;

    void Start()
    {
        objectiveUI = GameObject.Find("objectiveImage");
        isElevatorDoorOpen = GameObject.FindGameObjectWithTag("ElevatorDoor").GetComponent<ElevatorDoorStats>().isDoorOpen;
        objectiveText = objectiveUI.GetComponentInChildren<Text>();
        objectiveText.text = "";
        player = GameObject.FindGameObjectWithTag("Player");
        objectiveUI.SetActive(false);
    }

    void Update()
    {
        ToggleObjective();
        ObjectiveTask();
    }

    private bool HasPlayerKeycard()
    {
        if (player.GetComponent<PlayerStats>().isKeycardLooted)
        {
            return true;
        }
        else
            return false;
    }

    private void ToggleObjective()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (objectiveUI.activeSelf == false)
            {
                objectiveUI.SetActive(true);
            }
            else
                objectiveUI.SetActive(false);
        }
    }

    private void ObjectiveTask()
    {        
        if (SceneCount.GetCurrentSceneInt() == 1)
        {
            isElevatorDoorOpen = GameObject.FindGameObjectWithTag("ElevatorDoor").GetComponent<ElevatorDoorStats>().isDoorOpen;
            if (HasPlayerKeycard() && isElevatorDoorOpen)
            {
                objectiveText.text = "Зайдите в лифт";
            }
            else if (!HasPlayerKeycard())
            {
                objectiveText.text = "Подберите ключ-карту с одного из наёмников";
            }
            else
            {
                objectiveText.text = "Используйте ключ-карту на пульте управления лифтом";
            }
        }
        else if (SceneCount.GetCurrentSceneInt() == 2)
        {
            objectiveText.text = "Покиньте базу через центральный вход";
        }
    }
}
