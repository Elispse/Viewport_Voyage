using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour
{
    //private int sampleItems = 4;
    
    [SerializeField] private Text sampleText;
    public bool isPoweredOn = false;
    public bool inContact = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            Debug.Log("Enter Collision");
            inContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit Collision");
            inContact = false;
        }
    }
    private void Update()
    {
                if (Input.GetButtonDown("Interact") && inContact)
                {
                    sampleText.text = "INTERACT";
                    Debug.Log("Interacted");
                    isPoweredOn = (!isPoweredOn) ? true : false;
                }
    
    }
}
