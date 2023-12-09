using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public InteractObject lever;
    public DoorState door;
    private Animator anim;

    public bool inContact = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ExitLevel" || collision.tag == "SecretLevel")
        {           
            Debug.Log("Player has Entered Collision w/ Door");
            inContact = true;

            if (collision.GetComponent<DoorState>()) door = collision.GetComponent<DoorState>();
            if (collision.GetComponent<InteractObject>()) lever = collision.GetComponent<InteractObject>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ExitLevel" || collision.tag == "SecretLevel")
        {
            Debug.Log("Player has Exited Collision w/ Door");
            inContact = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (inContact && lever.isPoweredOn && lever.Active && Input.GetButtonDown("Enter_Door"))
        {
            Debug.Log("Loading next scene");
            SceneManager.LoadScene(door.nextSceneID);
        }
    }
}
