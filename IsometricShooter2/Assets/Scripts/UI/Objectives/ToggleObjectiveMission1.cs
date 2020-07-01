using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleObjectiveMission1 : MonoBehaviour
{
    private GameObject objectiveUI;
    private Text objectiveText;
    private GameObject player;
    private bool isElevatorDoorOpen;

    void Start()
    {
        objectiveUI = GameObject.Find("objectiveImage");
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            isElevatorDoorOpen = GameObject.FindGameObjectWithTag("ElevatorDoor").GetComponent<ElevatorDoorStats>().isDoorOpen;
        }        
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
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().isKeycardLooted)
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            isElevatorDoorOpen = GameObject.FindGameObjectWithTag("ElevatorDoor").GetComponent<ElevatorDoorStats>().isDoorOpen;            
            if (!HasPlayerKeycard())
            {
                objectiveText.text = "Уничтожайте наёмников, пока из одного из них не выпадет ключ-карта. Подберите её";
            }
            else
            {
                if (HasPlayerKeycard() && isElevatorDoorOpen)
                {
                    objectiveText.text = "Зайдите в лифт";
                }
                else
                    objectiveText.text = "Используйте ключ-карту на пульте управления лифтом";
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            objectiveText.text = "Покиньте базу через центральный вход";
        }
    }
}
