using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDoorScript : MonoBehaviour
{
    SpriteRenderer renderer;
    public InteractObject lever;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lever.isPoweredOn)
        {
            renderer.color = new Color(0,0,1,1);
        }else
        {
            renderer.color = new Color(1,0,0,1);
        }
    }


}
