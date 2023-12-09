using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractObject : MonoBehaviour
{
    private Animator anim;

    [SerializeField] private Text sampleText;
    public bool isPoweredOn = false;
    public bool inContact = false;
    public bool Active = false;
    private int isColliding = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {           
            Debug.Log("Player has Entered Collision w/ Lever");
            inContact = true;
        }

        if (collision.gameObject.CompareTag("Unmask")) isColliding++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has Exited Collision w/ Lever");
            inContact = false;
        }

        if (collision.gameObject.CompareTag("Unmask")) isColliding--;
    }

    private void Update()
    {
        if (isColliding != 0) Active = true;
        else Active = false;

        if (isPoweredOn && !Active) isPoweredOn = false;

        if (Input.GetButtonDown("Interact") && inContact)
        {
            if (!isPoweredOn)
            {
                sampleText.text = "LEVER ON";
                Debug.Log("Lever Turned On");
                isPoweredOn = true;
            }
            else
            {
                sampleText.text = "LEVER OFF";
                Debug.Log("Lever Turned Off");
                isPoweredOn = false;
            }

        }        
        
        if (gameObject.tag == "Lever") UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (isPoweredOn) anim.SetBool("state", true);
        else anim.SetBool("state", false);
    }
}
