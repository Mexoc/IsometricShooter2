using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardLoot : MonoBehaviour
{
    private GameObject keycard;
    private GameObject keycardImageUI;

    void Awake()
    {
        keycardImageUI = GameObject.Find("keycardImage");
        keycardImageUI.SetActive(false);
    }

    private GameObject Keycard
    {
       get { return keycard = GameObject.FindGameObjectWithTag("Keycard"); } 
       set
        {
            if (keycard == null)
            {
                return;
            }
        } 
    }

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<PlayerStats>().isKeycardLooted = true;
        keycardImageUI.SetActive(true);
        Destroy(gameObject);                  
    }
}
