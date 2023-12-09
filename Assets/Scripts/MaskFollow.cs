using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaskFollow : MonoBehaviour
{
    public Transform target; // Assign the player character to this variable
    private Vector3 startPos;

    private void Start()
    {
        if (target != null)
        {
            startPos = transform.position + new Vector3(target.position.x, target.position.y, target.position.z);
        }
    }

    private void Update()
    {
        if (target != null)
        {
            transform.position = startPos + new Vector3(target.position.x, target.position.y, target.position.z);
        }
    }
}
