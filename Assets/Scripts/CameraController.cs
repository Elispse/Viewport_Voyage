using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform control;         // Object's Transform that the Camera is following/looking at


    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(control.position.x, control.position.y, transform.position.z);
    }
}
