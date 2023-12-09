using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Hover : MonoBehaviour
{
    Renderer renderer;
    void Start()
    {
        renderer.material.color = Color.white;
    }

    // Update is called once per frame

    void OnMouseEnter()
    {
        renderer.material.color = Color.black;
    }

    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }
}
