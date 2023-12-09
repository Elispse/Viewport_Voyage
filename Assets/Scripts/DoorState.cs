using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorState : MonoBehaviour
{
    public InteractObject lever;
    public int nextSceneID;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (lever.isPoweredOn && lever.Active) anim.SetBool("open", true);
        else anim.SetBool("open", false);
    }
}
