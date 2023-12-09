using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorScript : MonoBehaviour
{
    [SerializeField] private GameObject control;

    private void Start()
    {
        if (this.name == "Anchor(Clone)")
        {
            control = GameObject.Find("Unmask (Anchor)");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        control.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
    }
}
