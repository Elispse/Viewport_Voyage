using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCamera : MonoBehaviour
{
    public SpriteRenderer target;

    // Start is called before the first frame update
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = target.bounds.size.x / target.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = target.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = target.bounds.size.y / 2 * differenceInSize;
        }
    }
}
