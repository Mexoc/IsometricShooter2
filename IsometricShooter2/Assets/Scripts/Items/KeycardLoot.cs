using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardLoot : MonoBehaviour
{
    private GameObject keycard;
    private GameObject keycardImageUI;

    private void OnTriggerEnter(Collider collision)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().isKeycardLooted = true;
        Destroy(gameObject);                  
    }
}
